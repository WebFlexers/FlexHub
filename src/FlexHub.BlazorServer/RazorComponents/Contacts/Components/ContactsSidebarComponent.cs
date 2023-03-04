using BlazorComponentBus;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ContactsSidebarComponent
{
    [Inject] public ILogger<ContactsSidebarComponent> Logger { get; set; } = null!;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IUserInfoStore UserInfoStore { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    private MatList _contactsList;
    private MatList _groupsList;

    private string _contactsSearchText = string.Empty;
    private string _groupsSearchText = string.Empty;

    public UserDTO? SelectedContact { get; set; } = new();
    public List<UserDTO>? Contacts { get; set; } = new();

    public GroupChatDTO? SelectedGroup { get; set; } = new();
    public List<GroupChatDTO>? Groups { get; set; } = new();

    public async Task LoadData()
    {
        if (UserInfoStore.UserDTO == null) return;

        Contacts = await UserRepository.GetUserContacts(UserInfoStore.UserDTO.ObjectId);
        if (Contacts != null && Contacts.Any())
        {
            SelectedContact = Contacts.First();
        }

        Groups = await GroupChatRepository.GetGroupChats(UserInfoStore.UserDTO.ObjectId);

        StateHasChanged();
    }

    private async Task OnContactListItemClick(UserDTO contact)
    {
        if (UserInfoStore.UserDTO == null) return;

        // Reset groups selection with hacks, 
        // since there isn't a method to do it for us...
        var groupsCopy = Groups?.ToList();
        Groups = new List<GroupChatDTO>();
        await Task.Delay(1);
        Groups = groupsCopy;
        await InvokeAsync(StateHasChanged);

        await ComponentBus.Publish(new ChatSourceChangedEvent
        {
            ChatType = ChatType.DirectMessages,
            LoggedInUserObjectId = UserInfoStore.UserDTO.ObjectId,
            ContactObjectId = contact.ObjectId
        });
    }

    private async Task OnGroupListItemClick(GroupChatDTO group)
    {
        if (UserInfoStore.UserDTO == null) return;

        // Reset contacts selection with hacks, 
        // since there isn't a method to do it for us...
        var contactsCopy = Contacts?.ToList();
        Contacts = new List<UserDTO>();
        await Task.Delay(1);
        Contacts = contactsCopy;
        await InvokeAsync(StateHasChanged);

        await ComponentBus.Publish(new ChatSourceChangedEvent
        {
            ChatType = ChatType.GroupChat,
            LoggedInUserObjectId = UserInfoStore.UserDTO.ObjectId,
            GroupChatId = group.Id
        });
    }

    public void Refresh()
    {
        StateHasChanged();
    }
}
