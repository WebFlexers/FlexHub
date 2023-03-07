using BlazorComponentBus;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.SignalR;
using FlexHub.BlazorServer.SignalR.Models;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ChatComponent
{
    public int ItemsPerPage { get; set; } = 10;

    [Inject] public ILogger<ChatComponent> Logger { get; set; } = null!;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IDirectMessageRepository DirectMessageRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    [Inject] public NavigationManager NavManager { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    private ChatSourceChangedEvent? _chatSource;
    private HubConnection? _hubConnection;

    private SendMessageModel _sendMessageModel = new();

    private List<DirectMessageModel> _directMessages = new();
    private List<GroupMessageModel> _groupMessages = new();

    private int _pageNum;
    private bool _isGroupSelected = false;

    protected override async Task OnInitializedAsync()
    {
        ComponentBus.Subscribe<ChatSourceChangedEvent>(OnChatSourceChanged);

        _hubConnection = new HubConnectionBuilder()
            .WithUrl(NavManager.ToAbsoluteUri("/chathub"))
            .WithAutomaticReconnect()
            .Build();

        _hubConnection.On<string, SignalRDirectMessageModel>(SignalRMessages.ReceiveDirectMessage, async (senderUserObjectId, dmModel) =>
        {
            if (_chatSource == null) return;

            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

            if (userDTO == null) return;

            if (userDTO.ObjectId.Equals(dmModel.ReceiverObjectId) && _chatSource.ContactObjectId.Equals(senderUserObjectId))
            {
                _directMessages.Insert(0, new DirectMessageModel
                {
                    Id = dmModel.DirectMessageId,
                    CreatedAt = dmModel.CreatedAt.ToLocalTime().ToString("h:mm tt | MMMM d"),
                    IsSentByTheLoggedInUser = false,
                    Message = dmModel.Message,
                });

                await InvokeAsync(StateHasChanged);
            }
        });

        _hubConnection.On<string, SignalRGroupMessageModel>(SignalRMessages.ReceiveGroupMessage, async (senderUserObjectId, groupModel) =>
        {
            if (_chatSource == null) return;

            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

            if (userDTO == null) return;
            
            if (groupModel.GroupId.Equals(_chatSource.GroupChatId) && userDTO.ObjectId.Equals(senderUserObjectId) == false)
            {
                _groupMessages.Insert(0, new GroupMessageModel
                {
                    Id = groupModel.GroupId,
                    CreatedAt = groupModel.CreatedAt.ToLocalTime().ToString("h:mm tt | MMMM d"),
                    IsSentByTheLoggedInUser = false,
                    Message = groupModel.Message,
                    SenderDisplayName = groupModel.SenderDisplayName
                });

                await InvokeAsync(StateHasChanged);
            }
        });

        try
        {
            await _hubConnection.StartAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An error occurred while trying to open SignalR connection");
        }
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
            CreatedAt = dm.CreatedAt.ToLocalTime().ToString("h:mm tt | MMMM d")
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
            CreatedAt = gm.CreatedAt.ToLocalTime().ToString("h:mm tt | MMMM d"),
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

        if (_isGroupSelected == false)
        {
            (bool isStoredSuccessfully, DirectMessage? directMessage) = await DirectMessageRepository.StoreMessage(userDTO.ObjectId, 
                _chatSource.ContactObjectId, _sendMessageModel.Message);

            if (_hubConnection == null) return;

            if (isStoredSuccessfully == false || directMessage == null) return;

            try
            {
                await _hubConnection.SendAsync(SignalRMessages.SendDirectMessage, userDTO.ObjectId,
                    new SignalRDirectMessageModel
                    {
                        ReceiverObjectId = _chatSource.ContactObjectId,
                        CreatedAt = directMessage.CreatedAt,
                        DirectMessageId = directMessage.Id,
                        Message = directMessage.Message
                    });

                _directMessages.Insert(0, new DirectMessageModel
                {
                    Id = directMessage.Id,
                    CreatedAt = directMessage.CreatedAt.ToLocalTime().ToString("h:mm tt | MMMM d"),
                    IsSentByTheLoggedInUser = true,
                    Message = directMessage.Message
                });

                _sendMessageModel.Message = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while trying to send direct message through SignalR");
            }
        }
        else
        {
            (bool isStoredSuccessfully, GroupMessage? groupMessage) = await GroupChatRepository.StoreGroupMessage(userDTO.ObjectId, 
                _chatSource.GroupChatId, _sendMessageModel.Message);

            if (_hubConnection == null) return;

            if (isStoredSuccessfully == false || groupMessage == null) return;

            try
            {
                await _hubConnection.SendAsync(SignalRMessages.SendGroupMessage, userDTO.ObjectId,
                    new SignalRGroupMessageModel
                    {
                        GroupId = groupMessage.GroupChatId,
                        CreatedAt = groupMessage.CreatedAt,
                        Message = groupMessage.Message,
                        SenderDisplayName = userDTO.DisplayName
                    });

                _groupMessages.Insert(0, new GroupMessageModel
                {
                    Id = groupMessage.Id,
                    CreatedAt = groupMessage.CreatedAt.ToLocalTime().ToString("h:mm tt | MMMM d"),
                    IsSentByTheLoggedInUser = true,
                    Message = groupMessage.Message,
                    SenderDisplayName = userDTO.DisplayName
                });

                _sendMessageModel.Message = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while trying to send group message through SignalR");
            }
        }
    }
}
