using FlexHub.Data.DTOs;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Gets the user with the given display name
    /// </summary>
    Task<UserDTO?> GetUserByDisplayName(string displayName);

    /// <summary>
    /// Gets the user display name of the user with the given object id
    /// </summary>
    Task<UserDTO?> GetUserById(string userObjectId);

    /// <summary>
    /// Gets the last X number of contacts of the user asynchronously
    /// </summary>
    /// <param name="userObjectId">The object Id of the user</param>
    /// <param name="numberOfContacts">The number of contacts to load</param>
    Task<List<UserDTO>?> GetLastAddedContacts(string userObjectId, int numberOfContacts);

    /// <summary>
    /// Gets all the user contacts asynchronously
    /// </summary>
    Task<List<UserDTO>?> GetUserContacts(string userObjectId);

    /// <summary>
    /// Gets the contacts of the given user
    /// that contain the given name asynchronously
    /// </summary>
    Task<List<UserDTO>?> GetUserContactsFilteredByName(string userObjectId, string name);

    /// <summary>
    /// Gets all the contact requests of the user with the given id asynchronously
    /// </summary>
    Task<List<ContactRequestDTO>?> GetUserContactRequests(string userObjectId);

    /// <summary>
    /// Checks if two users are contacts asynchronously
    /// </summary>
    Task<bool> AreUsersContacts(string userObjectId, string contactObjectId);

    /// <summary>
    /// Creates a user from the given UserDTO asynchronously
    /// <returns>True if the user was created successfully and false otherwise</returns>
    /// </summary>
    Task<bool> CreateUser(UserDTO userDTO);

    /// <summary>
    /// Updates a user from the given UserDTO asynchronously
    /// <returns>True if the user was updated successfully and false otherwise</returns>
    /// </summary>
    Task<bool> UpdateUser(UserDTO userDTO);

    /// <summary>
    /// Creates a contact request from the primary user asynchronously
    /// to the receiver user
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<(bool isSuccessfull, string errorMessage)> CreateContactRequest(string senderUserObjectId, string receiverUserObjectId);

    /// <summary>
    /// Accepts the user request from the sender user to the primary user and
    /// adds the users to the contacts table asynchronously
    /// </summary>
    /// <param name="receiverUserObjectId">The receiving user object id</param>
    /// <param name="senderUserObjectId">The user object id of the user who sent the contact request</param>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> AcceptContactRequest(string receiverUserObjectId, string senderUserObjectId);

    /// <summary>
    /// Rejects the user request from the sender user to the primary user by
    /// deleting the contact request from the contact requests table asynchronously
    /// </summary>
    /// <param name="receiverUserObjectId">The receiving user object id</param>
    /// <param name="senderUserObjectId">The user object id of the user who sent the contact request</param>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> RejectContactRequest(string receiverUserObjectId, string senderUserObjectId);

    /// <summary>
    /// Deletes the contact between the primary user and the contact asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> DeleteContact(string primaryUserObjectId, string contactToDeleteUserObjectId);
}