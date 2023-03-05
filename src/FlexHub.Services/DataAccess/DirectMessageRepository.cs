using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using FlexHub.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class DirectMessageRepository : EfCoreRepositoryBase, IDirectMessageRepository
{
    private readonly ILogger<DirectMessageRepository> _logger;

    public DirectMessageRepository(ILogger<DirectMessageRepository> logger, IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _logger = logger;
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
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var messages = await dbContext.DirectMessages
            .Where(dm => 
                (dm.SenderUserObjectId == primaryUserObjectId && dm.ReceiverUserObjectId == contactUserObjectId) ||
                (dm.SenderUserObjectId == contactUserObjectId && dm.ReceiverUserObjectId == primaryUserObjectId))
            .OrderByDescending(dm => dm.CreatedAt)
            .Paginate(pageNumber, numberOfMessagesToLoad)
            .Select(dm => new DirectMessageDTO()
            {
                Id = dm.Id,
                Message = dm.Message,
                CreatedAt = dm.CreatedAt,
                SenderUserObjectId = dm.SenderUserObjectId,
                ReceiverUserObjectId = dm.ReceiverUserObjectId,
            }).ToListAsync().ConfigureAwait(false);

            return messages;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get direct messages");
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Stores a message sent from the sender user to the receiver user asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> StoreMessage(string senderUserObjectId, string receiverUserObjectId, string message)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var nowUtc = DateTime.UtcNow;

            DirectMessage directMessage = new()
            {
                Message = message,
                CreatedAt = nowUtc,
                SenderUserObjectId = senderUserObjectId,
                ReceiverUserObjectId = receiverUserObjectId
            };

            dbContext.DirectMessages.Add(directMessage);

            await dbContext.SaveChangesAsync().ConfigureAwait(false);

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
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }
}
