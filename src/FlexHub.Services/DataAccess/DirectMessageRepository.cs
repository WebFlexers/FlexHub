using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using FlexHub.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class DirectMessageRepository : IDirectMessageRepository
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
    public async Task<List<DirectMessageDTO>?> GetDirectMessagesOf2UsersPaginated(
        string primaryUserObjectId, string contactUserObjectId, int pageNumber, int numberOfMessagesToLoad)
    {

        try
        {
            var msgs = await _dbContext.DirectMessages
            .Where(dm => dm.SenderUserObjectId == primaryUserObjectId && dm.ReceiverUserObjectId == contactUserObjectId)
            .Paginate(pageNumber, numberOfMessagesToLoad)
            .Select(dm => new DirectMessageDTO()
            {
                Message = dm.Message,
                CreatedAt = dm.CreatedAt,
                SenderUserObjectId = primaryUserObjectId,
                ReceiverUserObjectId = contactUserObjectId
            }).ToListAsync().ConfigureAwait(false);

            return msgs;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get direct messages");
            return default;
        }
    }

    /// <summary>
    /// Stores a message sent from the sender user to the receiver user asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> StoreMessage(string senderUserObjectId, string receiverUserObjectId, string message)
    {
        try
        {
            var nowUtc = DateTime.UtcNow;

            DirectMessage directMessage = new()
            {
                Message = message,
                CreatedAt = nowUtc,
                SenderUserObjectId = senderUserObjectId,
                ReceiverUserObjectId = receiverUserObjectId
            };

            _dbContext.DirectMessages.Add(directMessage);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation("Successfully stored direct message from {id1} to {id2}", senderUserObjectId,
                receiverUserObjectId);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to store a direct message from {id1} to {id2}",
                senderUserObjectId, receiverUserObjectId);
            return false;
        }
    }
}
