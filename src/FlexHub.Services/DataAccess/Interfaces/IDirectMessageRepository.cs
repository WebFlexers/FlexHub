using FlexHub.Data.DTOs;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface IDirectMessageRepository
{
    /// <summary>
    /// Gets X number of direct messages between 2 users asynchronously
    /// sorted by time descending
    /// </summary>
    /// <param name="primaryUserObjectId">The logged in user object id</param>
    /// <param name="contactUserObjectId">The contact user object id</param>
    /// <param name="pageNumber">The page number</param>
    /// <param name="numberOfMessagesToLoad">The number of messages to load</param>
    Task<List<DirectMessageDTO>?> GetDirectMessagesOf2UsersPaginated(
        string primaryUserObjectId, string contactUserObjectId, int pageNumber, int numberOfMessagesToLoad);

    /// <summary>
    /// Stores a message sent from the sender user to the receiver user asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> StoreMessage(string senderUserObjectId, string receiverUserObjectId, string message);
}