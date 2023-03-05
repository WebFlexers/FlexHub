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
    public async Task<bool> StoreGroupMessage(string senderUserObjectId, int groupChatId, string message)
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

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to store message to group chat with id " + groupChatId);

            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }
}
