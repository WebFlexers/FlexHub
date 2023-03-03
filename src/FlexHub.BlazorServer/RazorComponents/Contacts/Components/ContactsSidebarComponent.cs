using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ContactsSidebarComponent
{
    [Inject] public IUserInfoStore UserInfoStore { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    public UserDTO? SelectedContact { get; set; }
    public List<UserDTO>? Contacts { get; set; }

    public GroupChatDTO? SelectedGroup { get; set; }
    public List<GroupChatDTO>? Groups { get; set; }

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

    public void Refresh()
    {
        StateHasChanged();
    }
}
