using BlazorComponentBus;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ContactsSidebarComponent
{
    [Inject] public ILogger<ContactsSidebarComponent> Logger { get; set; } = null!;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    private string _contactsSearchText = string.Empty;
    private string _groupsSearchText = string.Empty;

    public List<UserDTO>? Contacts { get; set; } = new();
    public List<GroupChatDTO>? Groups { get; set; } = new();

    public async Task LoadData()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        Contacts = await UserRepository.GetUserContacts(userDTO.ObjectId);
        Groups = await GroupChatRepository.GetGroupChats(userDTO.ObjectId);

        await InvokeAsync(StateHasChanged);

        // Load the messages of the first contact
        if (Contacts != null && Contacts.Any())
        {
            await PublishChatSourceChangedEvent(ChatType.DirectMessages, Contacts.First());
            await _contactsList.SetSelectedIndex(0);
        }
    }

    private async Task OnContactListItemClick(UserDTO contact)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        // Reset groups selection with hacks, 
        // since there isn't a method to do it for us...
        var groupsCopy = Groups?.ToList();
        Groups = new List<GroupChatDTO>();
        await Task.Delay(1);
        Groups = groupsCopy;
        await InvokeAsync(StateHasChanged);

        await PublishChatSourceChangedEvent(ChatType.DirectMessages, contact: contact);
    }

    private async Task OnGroupListItemClick(GroupChatDTO group)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        // Reset contacts selection with hacks, 
        // since there isn't a method to do it for us...
        var contactsCopy = Contacts?.ToList();
        Contacts = new List<UserDTO>();
        await Task.Delay(1);
        Contacts = contactsCopy;
        await InvokeAsync(StateHasChanged);

        await PublishChatSourceChangedEvent(ChatType.GroupChat, group: group);
    }

    public async Task PublishChatSourceChangedEvent(ChatType chatType, UserDTO? contact = null, GroupChatDTO? group = null)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (chatType == ChatType.DirectMessages)
        {
            if (contact == null) return;

            await ComponentBus.Publish(new ChatSourceChangedEvent
            {
                ChatType = ChatType.DirectMessages,
                LoggedInUserObjectId = userDTO.ObjectId,
                ContactObjectId = contact.ObjectId
            });
        }
        else
        {
            if (group == null) return;

            await ComponentBus.Publish(new ChatSourceChangedEvent
            {
                ChatType = ChatType.GroupChat,
                LoggedInUserObjectId = userDTO.ObjectId,
                GroupChatId = group.Id
            });
        }
    }

    public void Refresh()
    {
        StateHasChanged();
    }
}
