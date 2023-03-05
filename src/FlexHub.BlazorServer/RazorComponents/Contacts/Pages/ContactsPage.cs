using FlexHub.BlazorServer.RazorComponents.Contacts.Components;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Pages;

public partial class ContactsPage
{
    [Inject] public ILogger<ContactsPage> Logger { get; set; } = null!;

    public ChatComponent? ChatComponent { get; set; }
    public ContactsSidebarComponent? ContactsSidebarComponent { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false) return;

        if (ContactsSidebarComponent == null) return;

        await ContactsSidebarComponent.LoadData();
    }
}
