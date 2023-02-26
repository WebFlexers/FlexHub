using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class GroupChatRepository
{
    private readonly ILogger<GroupChatRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public GroupChatRepository(ILogger<GroupChatRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets the group chats of the given user
    /// whose title contains the given title asynchronously
    /// </summary>
    public async Task<List<GroupChatDTO>> GetGroupChatsFilteredByName(string userObjectId, string groupChatTitle)
    {
        try
        {
            var groupChats = await _dbContext.UsersGroupChats
                .Where(groupChat => groupChat.UserObjectId == userObjectId && groupChat.GroupChat.Title.Contains(groupChatTitle))
                .Select(groupChat => new GroupChatDTO
                {
                    Id = groupChat.GroupChat.Id,
                    Title = groupChat.GroupChat.Title,
                    CreatedAt = groupChat.GroupChat.CreatedAt,
                    UpdatedAt = groupChat.GroupChat.UpdatedAt
                }).ToListAsync();

            return groupChats;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get group chats filtered by name");

            return default;
        }
    }

    /// <summary>
    /// Gets X number of messages that were sent to the given group chat
    /// paginated and sorted by time descending asynchronously
    /// </summary>
    /// <param name="groupChatId">The group chat id</param>
    /// <param name="pageNumber">The page number of the pagination</param>
    /// <param name="numberOfMessagesToLoad">The number of messages to load</param>
    public async Task<List<GroupMessageDTO>> GetSortedGroupMessagesPaginated(
        int groupChatId, int pageNumber, int numberOfMessagesToLoad)
    {
        try
        {
            var groupChatMessages = await _dbContext.GroupMessages
                .Where(groupChatMessage => groupChatMessage.GroupChatId == groupChatId)
                .Paginate(pageNumber, numberOfMessagesToLoad)
                .OrderBy(groupChatMessage => groupChatMessage.CreatedAt)
                .Select(groupChatMessage => new GroupMessageDTO()
                {
                    Message = groupChatMessage.Message,
                    CreatedAt = groupChatMessage.CreatedAt,
                    SenderUserObjectId = groupChatMessage.SenderUserObjectId,
                    GroupChatId = groupChatMessage.GroupChatId
                }).ToListAsync();

            return groupChatMessages;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get sorted group messages of group chat: " + groupChatId);

            return default;
        }
    }

    /// <summary>
    /// Stores a message sent by the sender user to the group chat asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> StoreGroupMessage(string senderUserObjectId, int groupChatId, string message)
    {
        try
        {
            var groupMessage = new GroupMessage()
            {
                Message = message,
                CreatedAt = DateTime.UtcNow,
                SenderUserObjectId = senderUserObjectId,
                GroupChatId = groupChatId
            };

            _dbContext.GroupMessages.Add(groupMessage);
            _dbContext.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to store message to group chat with id " + groupChatId);

            return false;
        }

        throw new NotImplementedException();
    }
}
