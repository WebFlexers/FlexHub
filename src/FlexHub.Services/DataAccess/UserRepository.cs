using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class UserRepository : EfCoreRepositoryBase, IUserRepository
{
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(ILogger<UserRepository> logger, IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets the user display name of the user with the given object id
    /// </summary>
    public async Task<UserDTO?> GetUser(string userObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var user = await dbContext.Users
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
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Gets the last X number of contacts of the user asynchronously
    /// </summary>
    /// <param name="userObjectId">The object Id of the user</param>
    /// <param name="numberOfContacts">The number of contacts to load</param>
    public async Task<List<UserDTO>?> GetLastAddedContacts(string userObjectId, int numberOfContacts)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var latestContacts = await dbContext.Contacts
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
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Gets all the user contacts asynchronously
    /// </summary>
    public async Task<List<UserDTO>?> GetUserContacts(string userObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var userContacts = await dbContext.Contacts
                .AsNoTracking()
                .Where(contact => contact.UserObjectId == userObjectId &&
                                  contact.ContactObjectId != userObjectId)
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

            var contactUsers = await dbContext.Contacts
                .AsNoTracking()
                .Where(contact => contact.ContactObjectId == userObjectId &&
                                  contact.UserObjectId != userObjectId)
                .OrderByDescending(c => c.CreatedAt)
                .Select(contact => new UserDTO
                {
                    ObjectId = contact.User.ObjectId,
                    EmailAddress = contact.User.EmailAddress,
                    GivenName = contact.User.GivenName,
                    Surname = contact.User.Surname,
                    DisplayName = contact.User.DisplayName,
                    Country = contact.User.Country,
                    CreatedAt = contact.User.CreatedAt,
                    UpdatedAt = contact.User.UpdatedAt,
                })
                .ToListAsync();

            var contacts = userContacts.Union(contactUsers).ToList();

            return contacts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get user contacts");
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Gets the contacts of the given user
    /// that contain the given name asynchronously
    /// </summary>
    public async Task<List<UserDTO>?> GetUserContactsFilteredByName(string userObjectId, string name)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var contacts = await dbContext.Contacts
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
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Creates a user from the given UserDTO
    /// <returns>True if the user was created successfully and false otherwise</returns>
    /// </summary>
    public async Task<bool> CreateUser(UserDTO userDTO)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var existingUser = await dbContext.Users.FindAsync(userDTO.ObjectId);

            if (existingUser == null)
            {
                await dbContext.AddAsync(new User
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

                await dbContext.SaveChangesAsync().ConfigureAwait(false);

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
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Updates a user from the given UserDTO
    /// <returns>True if the user was updated successfully and false otherwise</returns>
    /// </summary>
    public async Task<bool> UpdateUser(UserDTO userDTO)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var existingUser = await dbContext.Users.FindAsync(userDTO.ObjectId);

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

            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation("Successfully updated user with id {objectId}", existingUser.ObjectId);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to update a user");
            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Creates a contact request from the primary user
    /// to the receiver user
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> CreateContactRequest(string senderUserObjectId, string receiverUserObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var contactRequest = new ContactRequest()
            {
                SenderUserObjectId = senderUserObjectId,
                ReceiverUserObjectId = receiverUserObjectId,
            };

            await dbContext.ContactRequests.AddAsync(contactRequest).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create contact request");

            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
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
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            // Remove contact request
            var contactRequest = dbContext.ContactRequests
                .FirstOrDefault(contactRequest => contactRequest.SenderUserObjectId == senderUserObjectId && contactRequest.ReceiverUserObjectId == receiverUserObjectId);

            if (contactRequest != null)
            {
                dbContext.ContactRequests.Remove(contactRequest);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }

            // Add contact to user's contact list
            var contact = new Contact()
            {
                UserObjectId = receiverUserObjectId,
                ContactObjectId = senderUserObjectId,
                CreatedAt = DateTime.UtcNow
            };
            await dbContext.Contacts.AddAsync(contact).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to accept contact request");
            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Deletes the contact between the primary user and the contact to delete user asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> DeleteContact(string primaryUserObjectId, string contactToDeleteUserObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            // Find contact
            var contact = dbContext.Contacts
                .FirstOrDefault(contact => contact.UserObjectId == primaryUserObjectId && contact.ContactObjectId == contactToDeleteUserObjectId);

            if (contact != null)
            {
                dbContext.Contacts.Remove(contact);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete contact");
            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Removes the user with the given user object id
    /// from the group chat with the given id asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> RemoveUserFromGroupChat(string userObjectId, int groupChatId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var user = await dbContext.UsersGroupChats
                .Where(user => user.UserObjectId == userObjectId && user.GroupChatId == groupChatId)
                .FirstOrDefaultAsync();

            if (user == null) return false;

            dbContext.UsersGroupChats.Remove(user);
            await dbContext.SaveChangesAsync();

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to remove user from group chat");
            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }
}
