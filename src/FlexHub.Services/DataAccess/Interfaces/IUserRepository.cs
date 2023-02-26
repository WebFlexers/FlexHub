using FlexHub.Data.DTOs;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Gets the last X number of contacts of the user asynchronously
    /// </summary>
    /// <param name="userObjectId">The object Id of the user</param>
    /// <param name="numberOfContacts">The number of contacts to load</param>
    Task<List<UserDTO>> GetLastAddedContacts(string userObjectId, int numberOfContacts);

    /// <summary>
    /// Gets the contacts of the given user
    /// that contain the given name asynchronously
    /// </summary>
    Task<List<UserDTO>> GetUserContactsFilteredByName(string userObjectId, string name);

    /// <summary>
    /// Creates a user from the given UserDTO
    /// <returns>True if the user was created successfully and false otherwise</returns>
    /// </summary>
    Task<bool> CreateUser(UserDTO userDTO);

    /// <summary>
    /// Updates a user from the given UserDTO
    /// <returns>True if the user was updated successfully and false otherwise</returns>
    /// </summary>
    Task<bool> UpdateUser(UserDTO userDTO);

    /// <summary>
    /// Creates a contact request from the primary user
    /// to the receiver user
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> CreateContactRequest(string senderUserObjectId, string receiverUserObjectId);

    /// <summary>
    /// Accepts the user request from the sender user to the primary user and
    /// adds the users to the contacts table
    /// </summary>
    /// <param name="receiverUserObjectId">The receiving user object id</param>
    /// <param name="senderUserObjectId">The user object id of the user who sent the contact request</param>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> AcceptContactRequest(string receiverUserObjectId, string senderUserObjectId);

    /// <summary>
    /// Deletes the contact between the primary user and the contact to delete user asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> DeleteContact(string primaryUserObjectId, string contactToDeleteUserObjectId);

    /// <summary>
    /// Removes the user with the given user object id
    /// from the group chat with the given id asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> RemoveUserFromGroupChat(string userObjectId, int groupChatId);
}