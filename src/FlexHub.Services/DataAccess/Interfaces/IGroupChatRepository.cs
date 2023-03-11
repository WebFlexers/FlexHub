using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface IGroupChatRepository
{
    /// <summary>
    /// Gets all the group chats of the user asynchronously
    /// </summary>
    Task<List<GroupChatDTO>?> GetGroupChats(string userObjectId);

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
    Task<(bool isStoredSuccessfully, GroupMessage? groupMessage)> StoreGroupMessage(string senderUserObjectId, int groupChatId, string message);

    /// <summary>
    /// Creates a new group and returns a dto from it
    /// </summary>
    Task<(bool success, GroupChatDTO? newGroupChat)> CreateGroup(CreateGroupChatDTO createGroupDTO);

    /// <summary>
    /// Adds the user with the given object id to the groupChat with the given id
    /// </summary>
    /// <returns>Whether the operation was successful and an error message in case it wasn't</returns>
    Task<(bool success, string errorMessage)> AddUserToGroupChat(string userObjectId, int groupChatId);

    /// <summary>
    /// Removes the user with the given user object id
    /// from the group chat with the given id asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> RemoveUserFromGroupChat(string userObjectId, int groupChatId);
}