using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
        try
        {
            var latestContacts = await _dbContext.Contacts
                .Where(contact => contact.UserObjectId == userObjectId)
                .OrderByDescending(contact => contact.CreatedAt)
                .Take(numberOfContacts)
                .Select(contact => new UserDTO()
                {
                    ObjectId = contact.ContactUser.ObjectId,
                    EmailAddress = contact.ContactUser.EmailAddress,
                    GivenName = contact.ContactUser.GivenName,
                    Surname= contact.ContactUser.Surname,
                    DisplayName = contact.ContactUser.DisplayName,
                    Country = contact.ContactUser.Country,
                    CreatedAt = contact.ContactUser.CreatedAt,
                    UpdatedAt = contact.ContactUser.UpdatedAt,
                })
                .ToListAsync();

            return latestContacts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get latest contacts");

            return default;
        }
    }

    /// <summary>
    /// Gets the contacts of the given user
    /// that contain the given name asynchronously
    /// </summary>
    public async Task<List<UserDTO>> GetUserContactsFilteredByName(string userObjectId, string name)
    {
        try
        {
            var contacts = await _dbContext.Contacts
                .Where(contact => contact.UserObjectId == userObjectId && contact.ContactUser.DisplayName.Contains(name))
                .Select(contact => new UserDTO()
                {
                    ObjectId = contact.ContactUser.ObjectId,
                    EmailAddress = contact.ContactUser.EmailAddress,
                    GivenName = contact.ContactUser.GivenName,
                    Surname = contact.ContactUser.Surname,
                    DisplayName = contact.ContactUser.DisplayName,
                    Country = contact.ContactUser.Country,
                    CreatedAt = contact.ContactUser.CreatedAt,
                    UpdatedAt = contact.ContactUser.UpdatedAt,
                })
                .ToListAsync();

            return contacts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get contacts filtered by name");

            return default;
        }
    }

    /// <summary>
    /// Creates a contact request from the primary user
    /// to the receiver user
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> CreateContactRequest(string senderUserObjectId, string receiverUserObjectId)
    {
        try
        {
            var contactRequest = new ContactRequest()
            {
                SenderUserObjectId = senderUserObjectId,
                ReceiverUserObjectId = receiverUserObjectId,
            };

            _dbContext.ContactRequests.Add(contactRequest);
            _dbContext.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create contact request");

            return false;
        }
    }

    /// <summary>
    /// Accepts the user request from the sender user to the primary user and
    /// adds the users to the contacts table
    /// </summary>
    /// <param name="receiverUserObjectId">The receiving user object id</param>
    /// <param name="senderUserObjectId">The user object id of the user who sent the contact request</param>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> AcceptContactRequest(string receiverUserObjectId, string senderUserObjectId)
    {      
        try
        {
            // Remove contact request
            var contactRequest = _dbContext.ContactRequests
                .Where(contactRequest => contactRequest.SenderUserObjectId == senderUserObjectId && contactRequest.ReceiverUserObjectId == receiverUserObjectId)
                .FirstOrDefault();

            _dbContext.ContactRequests.Remove(contactRequest);
            _dbContext.SaveChanges();

            // Add contact to user's contact list
            var contact = new Contact()
            {
                UserObjectId = receiverUserObjectId,
                ContactObjectId = senderUserObjectId,
                CreatedAt = DateTime.UtcNow
            };
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to accept contact request");

            return false;
        }
    }

    /// <summary>
    /// Deletes the contact between the primary user and the contact to delete user asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> DeleteContact(string primaryUserObjectId, string contactToDeleteUserObjectId)
    {
        try
        {
            // Find contact
            var contact = _dbContext.Contacts
                .Where(contact => contact.UserObjectId == primaryUserObjectId && contact.ContactObjectId == contactToDeleteUserObjectId)
                .FirstOrDefault();

            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete contact");

            return false;
        }
    }

    /// <summary>
    /// Removes the user with the given user object id
    /// from the group chat with the given id asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> RemoveUserFromGroupChat(string userObjectId, int groupChatId)
    {
        throw new NotImplementedException(); 
    }
}
