using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ILogger<UserRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets the user display name of the user with the given object id
    /// </summary>
    public async Task<UserDTO?> GetUser(string userObjectId)
    {
        try
        {
            var user = await _dbContext.Users
                .FindAsync(userObjectId);

            if (user != null)
            {
                return new UserDTO
                {
                    ObjectId = user.ObjectId,
                    EmailAddress = user.EmailAddress,
                    GivenName = user.GivenName,
                    Surname = user.Surname,
                    DisplayName = user.DisplayName,
                    Country = user.Country,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                };
            }

            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get user display name with user object id: {id}", userObjectId);
            return default;
        }
    }

    /// <summary>
    /// Gets the last X number of contacts of the user asynchronously
    /// </summary>
    /// <param name="userObjectId">The object Id of the user</param>
    /// <param name="numberOfContacts">The number of contacts to load</param>
    public async Task<List<UserDTO>?> GetLastAddedContacts(string userObjectId, int numberOfContacts)
    {
        try
        {
            var latestContacts = await _dbContext.Contacts
                .Where(contact => contact.UserObjectId == userObjectId && contact.ContactObjectId != userObjectId)
                .OrderByDescending(contact => contact.CreatedAt)
                .Take(numberOfContacts)
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
                .ToListAsync().ConfigureAwait(false);

            return latestContacts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get latest contacts");
            return default;
        }
    }

    /// <summary>
    /// Gets all the user contacts asynchronously
    /// </summary>
    public async Task<List<UserDTO>?> GetUserContacts(string userObjectId)
    {
        try
        {
            var contacts = await _dbContext.Contacts
                .AsNoTracking()
                .Where(contact => contact.UserObjectId.Equals(userObjectId))
                .OrderByDescending(c => c.CreatedAt)
                .Select(contact => new UserDTO
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
            _logger.LogError(ex, "Failed to get user contacts");
            return default;
        }


    }

    /// <summary>
    /// Gets the contacts of the given user
    /// that contain the given name asynchronously
    /// </summary>
    public async Task<List<UserDTO>?> GetUserContactsFilteredByName(string userObjectId, string name)
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
                .ToListAsync().ConfigureAwait(false);

            return contacts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get contacts filtered by name");
            return default;
        }
    }

    /// <summary>
    /// Creates a user from the given UserDTO
    /// <returns>True if the user was created successfully and false otherwise</returns>
    /// </summary>
    public async Task<bool> CreateUser(UserDTO userDTO)
    {
        try
        {
            var existingUser = await _dbContext.Users.FindAsync(userDTO.ObjectId);

            if (existingUser == null)
            {
                await _dbContext.AddAsync(new User
                {
                    ObjectId = userDTO.ObjectId,
                    EmailAddress = userDTO.EmailAddress,
                    GivenName = userDTO.GivenName,
                    Surname = userDTO.Surname,
                    DisplayName = userDTO.DisplayName,
                    Country = userDTO.Country,
                    CreatedAt = userDTO.CreatedAt,
                    UpdatedAt = userDTO.UpdatedAt
                }).ConfigureAwait(false);

                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                _logger.LogInformation("Successfully created user with id {objectId}", userDTO.ObjectId);
                return true;
            }

            _logger.LogWarning("Tried to create user with object id: {objectId}, but they already existed", userDTO.ObjectId);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to create a user");
            return false;
        }
    }

    /// <summary>
    /// Updates a user from the given UserDTO
    /// <returns>True if the user was updated successfully and false otherwise</returns>
    /// </summary>
    public async Task<bool> UpdateUser(UserDTO userDTO)
    {
        try
        {
            var existingUser = await _dbContext.Users.FindAsync(userDTO.ObjectId);

            if (existingUser == null)
            {
                _logger.LogWarning("Tried to update user with object id: {objectId}, but they didn't exist in the database", userDTO.ObjectId);
                return false;
            }

            existingUser.EmailAddress = userDTO.EmailAddress;
            existingUser.GivenName = userDTO.GivenName;
            existingUser.Surname = userDTO.Surname;
            existingUser.DisplayName = userDTO.DisplayName;
            existingUser.Country = userDTO.Country;
            existingUser.UpdatedAt = userDTO.UpdatedAt;

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation("Successfully updated user with id {objectId}", existingUser.ObjectId);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to update a user");
            return false;
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

            await _dbContext.ContactRequests.AddAsync(contactRequest).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

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
                .FirstOrDefault(contactRequest => contactRequest.SenderUserObjectId == senderUserObjectId && contactRequest.ReceiverUserObjectId == receiverUserObjectId);

            if (contactRequest != null)
            {
                _dbContext.ContactRequests.Remove(contactRequest);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }

            // Add contact to user's contact list
            var contact = new Contact()
            {
                UserObjectId = receiverUserObjectId,
                ContactObjectId = senderUserObjectId,
                CreatedAt = DateTime.UtcNow
            };
            await _dbContext.Contacts.AddAsync(contact).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

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
                .FirstOrDefault(contact => contact.UserObjectId == primaryUserObjectId && contact.ContactObjectId == contactToDeleteUserObjectId);

            if (contact != null)
            {
                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }

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
        try
        {
            var user = await _dbContext.UsersGroupChats
                .Where(user => user.UserObjectId == userObjectId && user.GroupChatId == groupChatId)
                .FirstOrDefaultAsync();

            if (user == null) return false;

            _dbContext.UsersGroupChats.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to remove user from group chat");
            return false;
        }
    }
}
