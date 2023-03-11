using BlazorComponentBus;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.SignalR;
using FlexHub.BlazorServer.SignalR.Models;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;

namespace FlexHub.BlazorServer.Shared;

public partial class MainLayout
{
    [Inject] public ILogger<MainLayout> Logger { get; set; } = null!;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public NavigationManager NavManager { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    [Inject] public IMatToaster Toaster { get; set; } = null!;

    private HubConnection? _hubConnection;
    private List<GroupChatDTO>? _userGroupChats;

    protected override async Task OnInitializedAsync()
    {
        Toaster.Configuration.Position = MatToastPosition.TopRight;
        ComponentBus.Subscribe<UserGroupsChangedEvent>(UserGroupsChanged);

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        await Task.Run(async () =>
        {
            await UpdateGroupChats();
            await SetupSignalRConnection();
        });
    }

    private Task UserGroupsChanged(MessageArgs args, CancellationToken ct)
    {
        var groupsChangedArgs = args.GetMessage<UserGroupsChangedEvent>();

        _userGroupChats ??= new List<GroupChatDTO>();

        switch (groupsChangedArgs.GroupChangeType)
        {
            case GroupChangeType.Added:
                _userGroupChats.Add(groupsChangedArgs.GroupChat);
                break;
            case GroupChangeType.Removed:
                var groupChatToRemove = _userGroupChats.FirstOrDefault(gc => gc.Id == groupsChangedArgs.GroupChat.Id);
                if (groupChatToRemove != null)
                {
                    _userGroupChats.Remove(groupChatToRemove);
                }
                break;
            case GroupChangeType.None:
            default:
                Logger.LogError("Something went wrong while trying to update user groups");
                break;
        }

        return Task.CompletedTask;
    }

    private async Task UpdateGroupChats(List<GroupChatDTO>? userGroupChats = null)
    {
        var authStateOuter = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTOOuter = AuthUtilities.CreateUserDtoFromClaims(authStateOuter.User.Claims, Logger);

        if (userDTOOuter == null) return;

        if (userGroupChats == null)
        {
            _userGroupChats = await GroupChatRepository.GetGroupChats(userDTOOuter.ObjectId);
        }
        else
        {
            _userGroupChats = userGroupChats;
        }
    }

    private async Task SetupSignalRConnection()
    {
        _hubConnection = new HubConnectionBuilder()
        .WithUrl(NavManager.ToAbsoluteUri("/chathub"))
        .WithAutomaticReconnect()
            .Build();

        _hubConnection.On<string, SignalRDirectMessageModel>(SignalRMessages.ReceiveDirectMessage, async (senderUserObjectId, dmModel) =>
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

            if (userDTO == null) return;

            if (userDTO.ObjectId == dmModel.ReceiverObjectId)
            {
                ShowToastMessage(MatToastType.Info, "New Direct Message!",
                    $"You have a message from {dmModel.SenderDisplayName}");
            }
        });

        _hubConnection.On<string, SignalRGroupMessageModel>(SignalRMessages.ReceiveGroupMessage, async (senderUserObjectId, groupModel) =>
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

            if (userDTO == null) return;

            if (userDTO.ObjectId == senderUserObjectId) return;

            var groupChat = _userGroupChats?.FirstOrDefault(gc => gc.Id == groupModel.GroupId);

            if (groupChat == null) return;

            ShowToastMessage(MatToastType.Info, "New Group Message!",
                $"You have a message in {groupChat.Title} group chat from {groupModel.SenderDisplayName}");
 
        });

        try
        {
            await _hubConnection.StartAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An error occurred while trying to open SignalR connection");
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
