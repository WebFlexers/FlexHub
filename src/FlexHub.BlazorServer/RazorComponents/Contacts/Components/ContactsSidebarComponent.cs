using BlazorComponentBus;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.Components;

public partial class ContactsSidebarComponent
{
    [Inject] public ILogger<ContactsSidebarComponent> Logger { get; set; } = null!;

    [Inject] public IComponentBus ComponentBus { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public IGroupChatRepository GroupChatRepository { get; set; } = null!;

    [Inject] public IMatToaster Toaster { get; set; } = null!;

    [Inject] public IMatDialogService MatDialogService { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    public ContactsSearchModel ContactsSearchModel { get; set; } = new();
    public ContactsSearchModel GroupChatsSearchModel { get; set; } = new();

    public List<UserDTO>? Contacts { get; set; } = new();
    public List<GroupChatDTO>? Groups { get; set; } = new();

    private CreateGroupChatDTO _createGroupChatDTO = new();

    protected override void OnInitialized()
    {
        ComponentBus.Subscribe<ContactDeletedEvent>(OnContactDeleted);
        ComponentBus.Subscribe<UserLeftGroupEvent>(OnGroupLeave);
    }

    /// <summary>
    /// Loads the contacts and groups of the user
    /// </summary>
    public async Task LoadData()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        Contacts = await UserRepository.GetUserContacts(userDTO.ObjectId);
        Groups = await GroupChatRepository.GetGroupChats(userDTO.ObjectId);

        await InvokeAsync(StateHasChanged);

        // Load the messages of the first contact
        if (Contacts != null && Contacts.Any())
        {
            var tasks = new List<Task>
            {
                PublishChatSourceChangedEvent(ChatType.DirectMessages, Contacts.First()),
                _contactsList.SetSelectedIndex(0)
            };
            await Task.WhenAll(tasks);
        }
    }

    /// <summary>
    /// Loads the contacts that contain the search term in their name.
    /// If the search term is empty all the contacts are returned instead
    /// </summary>
    private async Task SearchContactsByName()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (string.IsNullOrWhiteSpace(ContactsSearchModel.Name))
        {
            Contacts = await UserRepository.GetUserContacts(userDTO.ObjectId);
            await InvokeAsync(StateHasChanged);
            return;
        }

        Contacts = await UserRepository.GetUserContactsFilteredByName(userDTO.ObjectId, ContactsSearchModel.Name);

        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Loads the groups that contain the search term in their name.
    /// If the search term is empty all the groups are returned instead
    /// </summary>
    private async Task SearchGroupChatsByName()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (string.IsNullOrWhiteSpace(GroupChatsSearchModel.Name))
        {
            Groups = await GroupChatRepository.GetGroupChats(userDTO.ObjectId);
            await InvokeAsync(StateHasChanged);
            return;
        }

        Groups = await GroupChatRepository.GetGroupChatsFilteredByName(userDTO.ObjectId, GroupChatsSearchModel.Name);

        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Removes the deleted contact from the list and updates the UI
    /// </summary>
    private async Task OnContactDeleted(MessageArgs args, CancellationToken ct)
    {
        if (Contacts == null) return;

        var contactDeletedArgs = args.GetMessage<ContactDeletedEvent>();
        var deletedContact = Contacts.FirstOrDefault(c => c.ObjectId == contactDeletedArgs.DeletedContactObjectId);

        if (deletedContact == null) return;

        Contacts.Remove(deletedContact);

        var tasks = new List<Task>
        {
            PublishChatSourceChangedEvent(ChatType.DirectMessages, Contacts.FirstOrDefault()),
            _contactsList.SetSelectedIndex(0)
        };
        await Task.WhenAll(tasks);

        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Removes the group that the user left from the list
    /// </summary>
    private async Task OnGroupLeave(MessageArgs args, CancellationToken ct)
    {
        if (Groups == null) return;

        var userLeftGroupArgs = args.GetMessage<UserLeftGroupEvent>();
        var removedGroup = Groups.FirstOrDefault(c => c.Id == userLeftGroupArgs.GroupId);

        if (removedGroup == null) return;

        Groups.Remove(removedGroup);

        var tasks = new List<Task>
        {
            ComponentBus.Publish(new UserGroupsChangedEvent
            {
                GroupChangeType = GroupChangeType.Removed,
                GroupChat = removedGroup
            }, ct),
            PublishChatSourceChangedEvent(ChatType.GroupChat, group: Groups.FirstOrDefault()),
            _contactsList.SetSelectedIndex(0)
        };
        await Task.WhenAll(tasks);

        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Notifies the chat component that a new contact was clicked. Also
    /// redraws the groups list in order to deselect a potentially selected group
    /// </summary>
    private async Task OnContactListItemClick(UserDTO contact)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        // Reset groups selection with hacks, 
        // since there isn't a method to do it for us...
        var groupsCopy = Groups?.ToList();
        Groups = new List<GroupChatDTO>();
        await Task.Delay(1);
        Groups = groupsCopy;
        await InvokeAsync(StateHasChanged);

        await PublishChatSourceChangedEvent(ChatType.DirectMessages, contact: contact);
    }

    /// <summary>
    /// Notifies the chat component that a new group was clicked. Also
    /// redraws the contacts list in order to deselect a potentially selected contact
    /// </summary>
    private async Task OnGroupListItemClick(GroupChatDTO group)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        // Reset contacts selection with hacks, 
        // since there isn't a method to do it for us...
        var contactsCopy = Contacts?.ToList();
        Contacts = new List<UserDTO>();
        await Task.Delay(1);
        Contacts = contactsCopy;
        await InvokeAsync(StateHasChanged);

        await PublishChatSourceChangedEvent(ChatType.GroupChat, group: group);
    }

    /// <summary>
    /// Notifies the chat component when the target contact or group changes
    /// </summary>
    public async Task PublishChatSourceChangedEvent(ChatType chatType, UserDTO? contact = null, GroupChatDTO? group = null)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (chatType == ChatType.DirectMessages)
        {
            if (contact == null) return;

            await ComponentBus.Publish(new ChatSourceChangedEvent
            {
                ChatType = ChatType.DirectMessages,
                LoggedInUserObjectId = userDTO.ObjectId,
                ContactObjectId = contact.ObjectId
            });
        }
        else
        {
            if (group == null) return;

            await ComponentBus.Publish(new ChatSourceChangedEvent
            {
                ChatType = ChatType.GroupChat,
                LoggedInUserObjectId = userDTO.ObjectId,
                GroupChatId = group.Id
            });
        }
    }

    public async Task CreateGroup()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        (bool groupCreated, GroupChatDTO? newGroupChatDTO) = await GroupChatRepository
            .CreateGroup(new CreateGroupChatDTO { Title =  _createGroupChatDTO.Title});

        if (groupCreated == false)
        {
            ShowToastMessage(MatToastType.Warning,
            "Failed to create group", 
            "The group chat could not be created. Try again later");
        }
        else
        {
            (bool addedSuccessfully, string errorMessage) = await GroupChatRepository
                .AddUserToGroupChat(userDTO.ObjectId, newGroupChatDTO!.Id);

            if (addedSuccessfully == false)
            {
                ShowToastMessage(MatToastType.Danger,
                    "Failed to create group", 
                    errorMessage);
                return;
            }

            Groups ??= new List<GroupChatDTO>();
            Groups.Add(newGroupChatDTO);

            ShowToastMessage(MatToastType.Success,
                "Success!", 
                $"Successfully created group chat with name {newGroupChatDTO.Title}");

            await ComponentBus.Publish(new UserGroupsChangedEvent
            {
                GroupChangeType = GroupChangeType.Added,
                GroupChat = newGroupChatDTO
            });

            await InvokeAsync(StateHasChanged);
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
