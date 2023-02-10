using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class UserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ILogger<UserRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets the last X number of contacts of the user asynchronously
    /// </summary>
    /// <param name="userObjectId">The object Id of the user</param>
    /// <param name="numberOfContacts">The number of contacts to load</param>
    public async Task<List<UserDTO>> GetLastAddedContacts(string userObjectId, int numberOfContacts)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the contacts of the given user
    /// that contain the given name asynchronously
    /// </summary>
    public async Task<List<UserDTO>> GetUserContactsFilteredByName(string userObjectId, string name)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a contact request from the primary user
    /// to the receiver user
    /// </summary>
    public async Task CreateContactRequest(string senderUserObjectId, string receiverUserObjectId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Accepts the user request from the sender user to the primary user and
    /// adds the users to the contacts table
    /// </summary>
    /// <param name="receiverUserObjectId">The receiving user object id</param>
    /// <param name="senderUserObjectId">The user object id of the user who sent the contact request</param>
    public async Task AcceptContactRequest(string receiverUserObjectId, string senderUserObjectId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the contact between the primary user and the contact to delete user asynchronously
    /// </summary>
    public async Task DeleteContact(string primaryUserObjectId, string contactToDeleteUserObjectId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes the user with the given user object id
    /// from the group chat with the given id asynchronously
    /// </summary>
    public async Task RemoveUserFromGroupChat(string userObjectId, int groupChatId)
    {
        throw new NotImplementedException(); 
    }
}
