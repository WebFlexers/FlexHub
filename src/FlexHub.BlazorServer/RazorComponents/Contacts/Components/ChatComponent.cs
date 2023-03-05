using BlazorComponentBus;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ChatComponent
{
    public int ItemsPerPage { get; set; } = 10;

    [Inject] public ILogger<ChatComponent> Logger { get; set; } = null!;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IDirectMessageRepository DirectMessageRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

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
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        _chatSource = args.GetMessage<ChatSourceChangedEvent>();

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

        _pageNum = 2;

        await ScrollDown();
    }

    private async Task FetchDirectMessages(int pageNumber, int itemsPerPage)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO== null) return;

        if (_chatSource == null) return;

        var newDirectMessages = await DirectMessageRepository
            .GetDirectMessagesOf2UsersPaginated(userDTO.ObjectId, 
                _chatSource.ContactObjectId, pageNumber, itemsPerPage);

        if (newDirectMessages == null) return;

        var directMessagesModels = newDirectMessages.Select(dm => new DirectMessageModel
        {
            Id = dm.Id,
            IsSentByTheLoggedInUser = userDTO.ObjectId.Equals(dm.SenderUserObjectId),
            Message = dm.Message,
            CreatedAt = dm.CreatedAt.ToString("h:mm tt | MMMM d")
        });

        _directMessages.AddRange(directMessagesModels);

        await Task.Delay(100);

        await InvokeAsync(StateHasChanged);
    }

    private async Task FetchGroupMessages(int pageNumber, int itemsPerPage)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (_chatSource == null) return;

        var newGroupMessages =
            await GroupChatRepository.GetSortedGroupMessagesPaginated(_chatSource.GroupChatId, pageNumber, itemsPerPage);

        if (newGroupMessages == null) return;

        var groupMessagesModels = newGroupMessages.Select(gm => new GroupMessageModel
        {
            Id = gm.Id,
            IsSentByTheLoggedInUser = userDTO.ObjectId.Equals(gm.SenderUserObjectId),
            Message = gm.Message,
            CreatedAt = gm.CreatedAt.ToString("h:mm tt | MMMM d"),
            SenderDisplayName = gm.SenderUserDisplayName
        });

        _groupMessages.AddRange(groupMessagesModels);

        await Task.Delay(100);

        await InvokeAsync(StateHasChanged);
    }

    public async Task SendMessage()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (_chatSource == null) return;

        if (string.IsNullOrWhiteSpace(_sendMessageModel.Message))
        {
            _sendMessageModel.Message = string.Empty;
            return;
        }

        var messageStoredSuccessfully = false;
        if (_isGroupSelected == false)
        {
            messageStoredSuccessfully = await DirectMessageRepository.StoreMessage(userDTO.ObjectId, 
                _chatSource.ContactObjectId, _sendMessageModel.Message);
        }
        else
        {
            messageStoredSuccessfully = await GroupChatRepository.StoreGroupMessage(userDTO.ObjectId,
                _chatSource.GroupChatId, _sendMessageModel.Message);
        }

        if (messageStoredSuccessfully == false) return;

        _sendMessageModel.Message = string.Empty;

    }
}
