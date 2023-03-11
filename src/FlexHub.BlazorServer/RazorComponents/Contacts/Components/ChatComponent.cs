using BlazorComponentBus;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.SignalR;
using FlexHub.BlazorServer.SignalR.Models;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ChatComponent
{
    public int ItemsPerPage { get; set; } = 10;

    [Inject] public ILogger<ChatComponent> Logger { get; set; } = null!;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public IDirectMessageRepository DirectMessageRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    [Inject] public NavigationManager NavManager { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    [Inject] public IMatToaster Toaster { get; set; } = null!;

    [Inject] public IMatDialogService MatDialogService { get; set; } = null!;

    private ChatSourceChangedEvent? _chatSource;
    private HubConnection? _hubConnection;

    private SendMessageModel _sendMessageModel = new();
    private AddUserToGroupModel _addUserToGroupModel = new();

    private List<DirectMessageModel> _directMessages = new();
    private List<GroupMessageModel> _groupMessages = new();

    private int _pageNum;
    private bool _isGroupSelected = false;

    private Task? _setupSignalRTask;

    protected override void OnInitialized()
    {
        _setupSignalRTask = SetupSignalRConnection();
        ComponentBus.Subscribe<ChatSourceChangedEvent>(OnChatSourceChanged);
    }

    /// <summary>
    /// Initiates the SignalR hub and listeners for real time messaging
    /// </summary>
    /// <returns></returns>
    private async Task SetupSignalRConnection()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(NavManager.ToAbsoluteUri("/chathub"))
            .WithAutomaticReconnect()
            .Build();

        _hubConnection.On<string, SignalRDirectMessageModel>(SignalRMessages.ReceiveDirectMessage, async (senderUserObjectId, dmModel) =>
        {
            if (_chatSource is not { ChatType: ChatType.DirectMessages }) return;

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
            if (_chatSource is not { ChatType: ChatType.GroupChat }) return;

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

    /// <summary>
    /// Fetches the correct direct or group messages according to the received notification
    /// </summary>
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

    /// <summary>
    /// Fetches the messages of two contacts in a paginated manner
    /// </summary>
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

        if (pageNumber != 1)
        {
            // Wait a bit after loading the pages after the first to prevent
            // a bug that caused the scrollbar to remain at the top that caused
            // messages to constantly be triggered until there were no more 
            await Task.Delay(100);
        }
        
        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Fetches the group messages of the selected group in a paginated manner
    /// </summary>
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

        if (pageNumber != 1)
        {
            // Wait a bit after loading the pages after the first to prevent
            // a bug that caused the scrollbar to remain at the top that in turn caused
            // message loading to constantly be triggered until there were messages left
            await Task.Delay(100);
        }

        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Stores a message in the database, sends it through SignalR to the
    /// correct contact or group participants and clears the message input field
    /// </summary>
    public async Task SendMessage()
    {
        if (_setupSignalRTask == null) return;
        await _setupSignalRTask;

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
                        SenderDisplayName = userDTO.DisplayName,
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

    /// <summary>
    /// Deletes the currently selected contact of the logged in user
    /// </summary>
    public async Task DeleteContact()
    {
        if (_chatSource == null) return;

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        var isContactDeleted = await UserRepository.DeleteContact(userDTO.ObjectId, _chatSource.ContactObjectId);

        if (isContactDeleted == false)
        {
            ShowToastMessage(
                MatToastType.Danger, 
                "Failed to delete contact!", 
                "Something went wrong while trying to delete the contact. Try again later"
            );

            return;
        }

        await ComponentBus.Publish(new ContactDeletedEvent
        {
            DeletedContactObjectId = _chatSource.ContactObjectId
        });

        ShowToastMessage(
            MatToastType.Success, 
            "Success!", 
            "Successfully deleted contact"
        );
    }

    /// <summary>
    /// Removes the logged in user from the currently selected group
    /// </summary>
    public async Task LeaveGroup()
    {
        if (_chatSource == null) return;

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        var hasUserLeftGroup = await GroupChatRepository.RemoveUserFromGroupChat(userDTO.ObjectId, _chatSource.GroupChatId);

        if (hasUserLeftGroup == false)
        {
            ShowToastMessage(
                MatToastType.Danger, 
                "Failed to delete contact!", 
                "Something went wrong while trying to delete the contact. Try again later"
            );

            return;
        }

        await ComponentBus.Publish(new UserLeftGroupEvent()
        {
            GroupId = _chatSource.GroupChatId
        });

        ShowToastMessage(
            MatToastType.Success, 
            "Success!", 
            "Successfully left the group"
        );
    }

    public async Task AddUserToGroup()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (_chatSource == null || _chatSource.ChatType == ChatType.DirectMessages)
        {
            return;
        }

        var userToAdd = await UserRepository.GetUserByDisplayName(_addUserToGroupModel.UserDisplayName);

        if (userToAdd == null)
        {
            ShowToastMessage(MatToastType.Warning,
                "Failed to add user to group", 
                "The display name you provided does not exist");
            return;
        }

        (bool successfullyAdded, string errorMessage) = await GroupChatRepository.AddUserToGroupChat(userToAdd.ObjectId, _chatSource.GroupChatId);

        if (successfullyAdded == false)
        {
            ShowToastMessage(MatToastType.Warning,
                "Failed to add user to group. Try again later.", 
                errorMessage);
        }
        else
        {
            ShowToastMessage(MatToastType.Success,
                "Success!", 
                $"Successfully added user {userToAdd.DisplayName} to group");
            _addUserToGroupModel.UserDisplayName = string.Empty;
        }
    }

    public void ShowToastMessage(MatToastType type, string title, string message, string icon = "")
    {
        Toaster.Add(message, type, title, icon, config =>
        {
            config.ShowCloseButton = true;
            config.ShowProgressBar = true;
            config.MaximumOpacity = Convert.ToInt32(100);
 
            config.ShowTransitionDuration = Convert.ToInt32(500);
            config.VisibleStateDuration = Convert.ToInt32(5000);
            config.HideTransitionDuration = Convert.ToInt32(500);
 
            config.RequireInteraction = false;
        });
    }
}
