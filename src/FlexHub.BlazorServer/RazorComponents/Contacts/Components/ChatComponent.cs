using BlazorComponentBus;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ChatComponent
{
    public int ItemsPerPage { get; set; } = 10;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IDirectMessageRepository DirectMessageRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    [Inject] public IUserInfoStore UserInfoStore { get; set; } = null!;

    private ChatSourceChangedEvent? _chatSource;

    private SendMessageModel _sendMessageModel = new();

    private List<DirectMessageModel> _directMessages = new();
    private List<GroupMessageModel> _groupMessages = new();

    private int _pageNum;
    private bool _isGroupSelected = false;

    protected override void OnInitialized()
    {
        ComponentBus.Subscribe<ChatSourceChangedEvent>(OnChatSourceChanged);
    }

    private async Task OnChatSourceChanged(MessageArgs args, CancellationToken ct)
    {
        if (UserInfoStore.UserDTO == null) return;

        await ScrollDown();

        _chatSource = args.GetMessage<ChatSourceChangedEvent>();
        _pageNum = 2;

        if (_chatSource.ChatType.Equals(ChatType.DirectMessages))
        {
            _isGroupSelected = false;
            _directMessages = new List<DirectMessageModel>();
            await FetchDirectMessages(1, ItemsPerPage);
        }
        else
        {
            _isGroupSelected = true;
            _groupMessages = new List<GroupMessageModel>();
            await FetchGroupMessages(1, ItemsPerPage);
        }
    }

    private async Task FetchDirectMessages(int pageNumber, int itemsPerPage)
    {
        if (UserInfoStore.UserDTO == null) return;

        if (_chatSource == null) return;

        var newDirectMessages = await DirectMessageRepository
            .GetDirectMessagesOf2UsersPaginated(UserInfoStore.UserDTO.ObjectId, 
                _chatSource.ContactObjectId, pageNumber, itemsPerPage);

        if (newDirectMessages == null) return;

        var directMessagesModels = newDirectMessages.Select(dm => new DirectMessageModel
        {
            IsSentByTheLoggedInUser = UserInfoStore.UserDTO.ObjectId.Equals(dm.SenderUserObjectId),
            Message = dm.Message,
            CreatedAt = dm.CreatedAt.ToString("h:mm tt | MMMM d")
        });

        _directMessages.AddRange(directMessagesModels);

        await InvokeAsync(StateHasChanged);
    }

    private async Task FetchGroupMessages(int pageNumber, int itemsPerPage)
    {
        if (UserInfoStore.UserDTO == null) return;

        if (_chatSource == null) return;

        var newGroupMessages =
            await GroupChatRepository.GetSortedGroupMessagesPaginated(_chatSource.GroupChatId, pageNumber, itemsPerPage);

        if (newGroupMessages == null) return;

        var groupMessagesModels = newGroupMessages.Select(gm => new GroupMessageModel
        {
            IsSentByTheLoggedInUser = UserInfoStore.UserDTO.ObjectId.Equals(gm.SenderUserObjectId),
            Message = gm.Message,
            CreatedAt = gm.CreatedAt.ToString("h:mm tt | MMMM d"),
            SenderDisplayName = gm.SenderUserDisplayName
        });

        _groupMessages.AddRange(groupMessagesModels);

        await InvokeAsync(StateHasChanged);
    }

    public async Task SendMessage()
    {
        if (UserInfoStore.UserDTO == null) return;

        if (_chatSource == null) return;

        if (string.IsNullOrWhiteSpace(_sendMessageModel.Message))
        {
            _sendMessageModel.Message = string.Empty;
            return;
        }

        var messageStoredSuccessfully = false;
        if (_isGroupSelected == false)
        {
            messageStoredSuccessfully = await DirectMessageRepository.StoreMessage(UserInfoStore.UserDTO.ObjectId, 
                _chatSource.ContactObjectId, _sendMessageModel.Message);
        }
        else
        {
            messageStoredSuccessfully = await GroupChatRepository.StoreGroupMessage(UserInfoStore.UserDTO.ObjectId,
                _chatSource.GroupChatId, _sendMessageModel.Message);
        }

        if (messageStoredSuccessfully == false) return;

        _sendMessageModel.Message = string.Empty;
    }
}
