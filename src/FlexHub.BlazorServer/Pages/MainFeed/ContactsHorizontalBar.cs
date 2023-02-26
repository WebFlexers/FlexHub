using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.Pages.MainFeed;

public partial class ContactsHorizontalBar
{
    [Inject]
    public IUserRepository UserRepository { get; set; }

    public List<UserDTO> RecentContacts { get; set; } = new();

    public async Task GetLastContactsOfUser(string userObjectId, int numberOfContacts)
    {
        RecentContacts = await UserRepository.GetLastAddedContacts(userObjectId, numberOfContacts);
        StateHasChanged();
    }
}
