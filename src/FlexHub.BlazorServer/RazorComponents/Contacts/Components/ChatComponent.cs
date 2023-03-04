using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using BlazorComponentBus;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ChatComponent
{
    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IDirectMessageRepository DirectMessageRepository { get; set; } = null!;

    [Inject] public IUserInfoStore UserInfoStore { get; set; } = null!;

    private SendDirectMessageModel _sendDirectMessageModel = new();
    private List<DirectMessageModel> _chatMessages = new();

    protected override void OnInitialized()
    {
        ComponentBus.Subscribe<ChatSourceChangedEvent>(OnChatSourceChanged);
    }

    private async Task OnChatSourceChanged(MessageArgs args, CancellationToken ct)
    {
        if (UserInfoStore.UserDTO == null) return;

        _chatMessages = new List<DirectMessageModel>();

        var chatSource = args.GetMessage<ChatSourceChangedEvent>();

        if (chatSource.ChatType.Equals(ChatType.DirectMessages))
        {
            var directMessages = await DirectMessageRepository
                .GetDirectMessagesOf2UsersPaginated(chatSource.LoggedInUserObjectId, 
                    chatSource.ContactObjectId, 1, 15);

            if (directMessages == null) return;

            var directMessagesModels = directMessages.Select(dm => new DirectMessageModel
            {
                IsSentByTheLoggedInUser = UserInfoStore.UserDTO.ObjectId.Equals(dm.SenderUserObjectId),
                Message = dm.Message,
                CreatedAt = dm.CreatedAt.ToString("h:mm tt | MMMM d")
            });

            _chatMessages.AddRange(directMessagesModels);
        }
        else
        {

        }

        await InvokeAsync(StateHasChanged);
    }

    public async Task SendMessage()
    {

    }
}
