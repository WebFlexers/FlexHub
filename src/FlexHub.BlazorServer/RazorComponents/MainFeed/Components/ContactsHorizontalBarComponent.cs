using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.RazorComponents.MainFeed.Components;

public partial class ContactsHorizontalBarComponent
{
    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    public List<UserDTO>? RecentContacts { get; set; } = new();

    public async Task GetLastContactsOfUser(string userObjectId, int numberOfContacts)
    {
        RecentContacts = await UserRepository.GetLastAddedContacts(userObjectId, numberOfContacts);
        StateHasChanged();
    }
}
