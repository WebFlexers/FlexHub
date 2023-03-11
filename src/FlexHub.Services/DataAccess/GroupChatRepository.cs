using System.Net.Http.Headers;
using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using FlexHub.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class GroupChatRepository : EfCoreRepositoryBase, IGroupChatRepository
{
    private readonly ILogger<GroupChatRepository> _logger;

    public GroupChatRepository(ILogger<GroupChatRepository> logger, IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets all the group chats of the user asynchronously
    /// </summary>
    public async Task<List<GroupChatDTO>?> GetGroupChats(string userObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var groupChats = await dbContext.UsersGroupChats
                .Where(userGroupChat => userGroupChat.UserObjectId == userObjectId)
                .Select(userGroupChat => new GroupChatDTO
                {
                    Id = userGroupChat.GroupChat.Id,
                    Title = userGroupChat.GroupChat.Title,
                    CreatedAt = userGroupChat.GroupChat.CreatedAt,
                    UpdatedAt = userGroupChat.GroupChat.UpdatedAt
                }).ToListAsync().ConfigureAwait(false);

            return groupChats;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get group chats filtered by name");
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Gets the group chats of the given user
    /// whose title contains the given title asynchronously
    /// </summary>
    public async Task<List<GroupChatDTO>?> GetGroupChatsFilteredByName(string userObjectId, string groupChatTitle)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var groupChats = await dbContext.UsersGroupChats
                .Where(groupChat => groupChat.UserObjectId == userObjectId && groupChat.GroupChat.Title.Contains(groupChatTitle))
                .Select(groupChat => new GroupChatDTO
                {
                    Id = groupChat.GroupChat.Id,
                    Title = groupChat.GroupChat.Title,
                    CreatedAt = groupChat.GroupChat.CreatedAt,
                    UpdatedAt = groupChat.GroupChat.UpdatedAt
                }).ToListAsync().ConfigureAwait(false);

            return groupChats;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get group chats filtered by name");
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Gets X number of messages that were sent to the given group chat
    /// paginated and sorted by time descending asynchronously
    /// </summary>
    /// <param name="groupChatId">The group chat id</param>
    /// <param name="pageNumber">The page number of the pagination</param>
    /// <param name="numberOfMessagesToLoad">The number of messages to load</param>
    public async Task<List<GroupMessageDTO>?> GetSortedGroupMessagesPaginated(
        int groupChatId, int pageNumber, int numberOfMessagesToLoad)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var groupChatMessages = await dbContext.GroupMessages
                .Where(groupChatMessage => groupChatMessage.GroupChatId == groupChatId)
                .OrderByDescending(groupChatMessage => groupChatMessage.CreatedAt)
                .Paginate(pageNumber, numberOfMessagesToLoad)
                .Select(groupChatMessage => new GroupMessageDTO()
                {
                    Id = groupChatMessage.Id,
                    Message = groupChatMessage.Message,
                    CreatedAt = groupChatMessage.CreatedAt,
                    SenderUserDisplayName = groupChatMessage.SenderUser.DisplayName,
                    SenderUserObjectId = groupChatMessage.SenderUserObjectId,
                    GroupChatId = groupChatMessage.GroupChatId
                }).ToListAsync().ConfigureAwait(false);

            return groupChatMessages;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get sorted group messages of group chat: " + groupChatId);
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Stores a message sent by the sender user to the group chat asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<(bool isStoredSuccessfully, GroupMessage? groupMessage)> StoreGroupMessage(string senderUserObjectId, int groupChatId, string message)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var groupMessage = new GroupMessage()
            {
                Message = message,
                CreatedAt = DateTime.UtcNow,
                SenderUserObjectId = senderUserObjectId,
                GroupChatId = groupChatId
            };

            await dbContext.GroupMessages.AddAsync(groupMessage);
            await dbContext.SaveChangesAsync();

            return (true, groupMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to store message to group chat with id " + groupChatId);

            return (false, default);
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Creates a new group and returns a dto from it
    /// </summary>
    public async Task<(bool success, GroupChatDTO? newGroupChat)> CreateGroup(CreateGroupChatDTO createGroupDTO)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var utcNow = DateTime.UtcNow;

            var newGroupChat = new GroupChat
            {
                Title = createGroupDTO.Title,
                CreatedAt = utcNow,
                UpdatedAt = utcNow
            };

            await dbContext.GroupChats.AddAsync(newGroupChat);
            await dbContext.SaveChangesAsync();

            var groupChatDTO = new GroupChatDTO
            {
                Id = newGroupChat.Id,
                Title = newGroupChat.Title,
                CreatedAt = newGroupChat.CreatedAt,
                UpdatedAt = newGroupChat.UpdatedAt
            };

            return (true, groupChatDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create group chat with title: " + createGroupDTO.Title);
            return (false, default);
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Adds the user with the given object id to the groupChat with the given id
    /// </summary>
    /// <returns>Whether the operation was successful and an error message in case it wasn't</returns>
    public async Task<(bool success, string errorMessage)> AddUserToGroupChat(string userObjectId, int groupChatId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var existingUserGroupRelationship = await dbContext.UsersGroupChats.FindAsync(userObjectId, groupChatId);

            if (existingUserGroupRelationship != null)
            {
                return (false, "The given user is already in the group");
            }

            await dbContext.UsersGroupChats.AddAsync(new UserGroupChat
            {
                UserObjectId = userObjectId,
                GroupChatId = groupChatId
            });

            await dbContext.SaveChangesAsync();

            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add user with id {userId} to group chat with id {chatId}", 
                userObjectId, groupChatId);
            return (false, "An unexpected error occurred while trying to add a user to the group chat");
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Removes the user with the given user object id
    /// from the group chat with the given id asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> RemoveUserFromGroupChat(string userObjectId, int groupChatId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var user = await dbContext.UsersGroupChats
                .Where(user => user.UserObjectId == userObjectId && user.GroupChatId == groupChatId)
                .FirstOrDefaultAsync();

            if (user == null) return false;

            dbContext.UsersGroupChats.Remove(user);
            await dbContext.SaveChangesAsync();

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to remove user from group chat");
            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }
}
