using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    /// <summary>
    /// Stores a message sent by the sender user to the group chat asynchronously
    /// </summary>
    public async Task StoreGroupMessage(string senderUserObjectId, int groupChatId, string message)
    {
        throw new NotImplementedException();
    }
}
