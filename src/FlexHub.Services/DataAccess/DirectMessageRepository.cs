using FlexHub.Data;
using FlexHub.Data.DTOs;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class DirectMessageRepository
{
    private readonly ILogger<DirectMessageRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public DirectMessageRepository(ILogger<DirectMessageRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets X number of direct messages between 2 users asynchronously
    /// sorted by time descending
    /// </summary>
    /// <param name="primaryUserObjectId">The logged in user object id</param>
    /// <param name="contactUserObjectId">The contact user object id</param>
    /// <param name="pageNumber">The page number</param>
    /// <param name="numberOfMessagesToLoad">The number of messages to load</param>
    public async Task<List<DirectMessageDTO>> GetDirectMessagesOf2UsersPaginated(
        string primaryUserObjectId, string contactUserObjectId, int pageNumber, int numberOfMessagesToLoad)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Stores a message sent from the sender user to the receiver user asynchronously
    /// </summary>
    public async Task StoreMessage(string senderUserObjectId, string receiverUserObjectId, string message)
    {
        throw new NotImplementedException();
    }
}
