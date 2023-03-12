using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.Profile.Components;

public partial class ProfileMainComponent
{
    [Inject] public ILogger<ProfileMainComponent> Logger { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    [Inject] public IMatToaster Toaster { get; set; } = null!;

    private UserDTO _userDTO = new();
    private SendContactRequestModel _sendContactRequestModel = new();

    private List<ContactRequestDTO>? _userContactRequests;

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        _userDTO = userDTO;

        _userContactRequests = await UserRepository.GetUserContactRequests(userDTO.ObjectId);
    }

    private async Task OnContactRequestSubmit()
    {
        if (string.IsNullOrWhiteSpace(_sendContactRequestModel.ContactDisplayName))
        {
            ShowToastMessage(
                MatToastType.Warning, 
                "Failed to send contact request", 
                "You did not type a display name. Type one and try again"
            );
            return;
        }

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (_sendContactRequestModel.ContactDisplayName == userDTO.DisplayName)
        {
            ShowToastMessage(
                MatToastType.Warning, 
                "Failed to send contact request", 
                "You can't add yourself to your contacts!"
            );
            return;
        }

        var contactUser = await UserRepository.GetUserByDisplayName(_sendContactRequestModel.ContactDisplayName);

        if (contactUser == null)
        {
            ShowToastMessage(
                MatToastType.Warning, 
                "User does not exist", 
                "The display name you typed does not correspond to a user. Make sure you typed it correctly"
            );
            return;
        }

        var isUserAlreadyContact = await UserRepository.AreUsersContacts(userDTO.ObjectId, contactUser.ObjectId);

        if (isUserAlreadyContact)
        {
            ShowToastMessage(
                MatToastType.Warning, 
                "User is already a contact", 
                "The user you typed is already in your contacts"
            );
            return;
        }

        var (isRequestSent, errorMessage) = await UserRepository.CreateContactRequest(userDTO.ObjectId, contactUser.ObjectId);

        if (isRequestSent == false)
        {
            ShowToastMessage(
                MatToastType.Warning, 
                "Failed to send contact request", 
                errorMessage
            );
        }
        else
        {
            ShowToastMessage(
                MatToastType.Success, 
                "Success!", 
                $"Successfully sent contact request to user: {_sendContactRequestModel.ContactDisplayName}"
            );
        }
    }

    public async Task AcceptContactRequest(string senderUserObjectId)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        var acceptedSuccessfully = await UserRepository.AcceptContactRequest(userDTO.ObjectId, senderUserObjectId);

        if (acceptedSuccessfully == false)
        {
            ShowToastMessage(
                MatToastType.Danger, 
                "Failed", 
                "Failed to accept contact request. Try again later."
            );
        }
        else
        {
            ShowToastMessage(
                MatToastType.Success, 
                "Success!", 
                "Successfully accepted contact request"
            );

            var contactRequest = _userContactRequests!.FirstOrDefault(cr =>
                cr.SenderUserObjectId == senderUserObjectId &&
                cr.ReceiverUserObjectId == userDTO.ObjectId);

            _userContactRequests!.Remove(contactRequest!);

            await InvokeAsync(StateHasChanged);
        }
    }

    public async Task RejectContactRequest(string senderUserObjectId)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        var rejectedSuccessfully = await UserRepository.RejectContactRequest(userDTO.ObjectId, senderUserObjectId);

        if (rejectedSuccessfully == false)
        {
            ShowToastMessage(
                MatToastType.Danger, 
                "Failed", 
                "Failed to reject contact request. Try again later."
            );
        }
        else
        {
            ShowToastMessage(
                MatToastType.Info, 
                "Success!", 
                "The contact request was rejected"
            );

            var contactRequest = _userContactRequests!.FirstOrDefault(cr =>
                cr.SenderUserObjectId == senderUserObjectId &&
                cr.ReceiverUserObjectId == userDTO.ObjectId);

            _userContactRequests!.Remove(contactRequest!);

            await InvokeAsync(StateHasChanged);
        }
    }

    public void ShowToastMessage(MatToastType type, string title, string message, string icon = "")
    {
        Toaster.Add(message, type, title, icon, config =>
        {
            config.ShowCloseButton = true;
            config.ShowProgressBar = true;
            config.MaximumOpacity = Convert.ToInt32(100);
 
            config.ShowTransitionDuration = Convert.ToInt32(500);
            config.VisibleStateDuration = Convert.ToInt32(5000);
            config.HideTransitionDuration = Convert.ToInt32(500);
 
            config.RequireInteraction = false;
        });
    }
}
