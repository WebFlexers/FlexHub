using FlexHub.BlazorServer.RazorComponents.Contacts.Components;
using FlexHub.BlazorServer.Stores.AuthToken;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Pages;

public partial class ContactsPage
{
    private Claim[]? _userClaims;

    [Inject] private IUserInfoStore UserInfoStore { get; set; } = null!;

    public ChatComponent? ChatComponent { get; set; }
    public ContactsSidebarComponent? ContactsSidebarComponent { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender == false) return;

        if (_userClaims == null) return;

        UserInfoStore.UserDTO ??= UserInfoStore.CreateUserDtoFromClaims(_userClaims);

        ContactsSidebarComponent?.LoadData();
    }
}
