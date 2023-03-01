using FlexHub.Data.DTOs;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface IGroupChatRepository
{
    /// <summary>
    /// Gets the group chats of the given user
    /// whose title contains the given title asynchronously
    /// </summary>
    Task<List<GroupChatDTO>?> GetGroupChatsFilteredByName(string userObjectId, string groupChatTitle);

    /// <summary>
    /// Gets X number of messages that were sent to the given group chat
    /// paginated and sorted by time descending asynchronously
    /// </summary>
    /// <param name="groupChatId">The group chat id</param>
    /// <param name="pageNumber">The page number of the pagination</param>
    /// <param name="numberOfMessagesToLoad">The number of messages to load</param>
    Task<List<GroupMessageDTO>?> GetSortedGroupMessagesPaginated(
        int groupChatId, int pageNumber, int numberOfMessagesToLoad);

    /// <summary>
    /// Stores a message sent by the sender user to the group chat asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> StoreGroupMessage(string senderUserObjectId, int groupChatId, string message);
}