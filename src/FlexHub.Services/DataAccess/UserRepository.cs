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
    /// Gets the user with the given display name
    /// </summary>
    public async Task<UserDTO?> GetUserByDisplayName(string displayName)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var user = await dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.DisplayName == displayName);

            if (user == null) return default;

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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get user with display name {name}", displayName);
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Gets the user display name of the user with the given object id
    /// </summary>
    public async Task<UserDTO?> GetUserById(string userObjectId)
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
                .Where(contact => 
                    (contact.UserObjectId == userObjectId && contact.ContactObjectId != userObjectId) ||
                    (contact.ContactObjectId == userObjectId && contact.UserObjectId != userObjectId))
                .OrderByDescending(contact => contact.CreatedAt)
                .Take(numberOfContacts)
                .Select(contact => new UserDTO()
                {
                    ObjectId = contact.UserObjectId == userObjectId ? contact.ContactObjectId : contact.UserObjectId,
                    EmailAddress = contact.UserObjectId == userObjectId ? contact.ContactUser.EmailAddress : contact.User.EmailAddress,
                    GivenName = contact.UserObjectId == userObjectId ? contact.ContactUser.GivenName : contact.User.GivenName,
                    Surname = contact.UserObjectId == userObjectId ? contact.ContactUser.Surname : contact.User.Surname,
                    DisplayName = contact.UserObjectId == userObjectId ? contact.ContactUser.DisplayName : contact.User.DisplayName,
                    Country = contact.UserObjectId == userObjectId ? contact.ContactUser.Country : contact.User.Country,
                    CreatedAt = contact.UserObjectId == userObjectId ? contact.ContactUser.CreatedAt : contact.User.CreatedAt,
                    UpdatedAt = contact.UserObjectId == userObjectId ? contact.ContactUser.UpdatedAt : contact.User.UpdatedAt,
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

            var contacts = await dbContext.Contacts
                .Where(contact => 
                    (contact.UserObjectId == userObjectId && contact.ContactObjectId != userObjectId) ||
                    (contact.ContactObjectId == userObjectId && contact.UserObjectId != userObjectId))
                .OrderByDescending(contact => contact.CreatedAt)
                .Select(contact => new UserDTO()
                {
                    ObjectId = contact.UserObjectId == userObjectId ? contact.ContactObjectId : contact.UserObjectId,
                    EmailAddress = contact.UserObjectId == userObjectId ? contact.ContactUser.EmailAddress : contact.User.EmailAddress,
                    GivenName = contact.UserObjectId == userObjectId ? contact.ContactUser.GivenName : contact.User.GivenName,
                    Surname = contact.UserObjectId == userObjectId ? contact.ContactUser.Surname : contact.User.Surname,
                    DisplayName = contact.UserObjectId == userObjectId ? contact.ContactUser.DisplayName : contact.User.DisplayName,
                    Country = contact.UserObjectId == userObjectId ? contact.ContactUser.Country : contact.User.Country,
                    CreatedAt = contact.UserObjectId == userObjectId ? contact.ContactUser.CreatedAt : contact.User.CreatedAt,
                    UpdatedAt = contact.UserObjectId == userObjectId ? contact.ContactUser.UpdatedAt : contact.User.UpdatedAt,
                })
                .ToListAsync().ConfigureAwait(false);

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
    /// Checks if two users are contacts
    /// </summary>
    public async Task<bool> AreUsersContacts(string userObjectId, string contactObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var result = await dbContext.Contacts
                .AsNoTracking()
                .FirstOrDefaultAsync(contact => 
                    (contact.UserObjectId == userObjectId && contact.ContactObjectId == contactObjectId) ||
                    contact.ContactObjectId == userObjectId && contact.UserObjectId == contactObjectId);

            return result != null;
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

            // ReSharper disable once SuspiciousTypeConversion.Global
            if (userDTO.Equals(existingUser))
            {
                _logger.LogWarning("Tried to update user with object id: {objectId}, but they were the same as before", userDTO.ObjectId);
                return false;
            }

            existingUser.EmailAddress = userDTO.EmailAddress;
            existingUser.GivenName = userDTO.GivenName;
            existingUser.Surname = userDTO.Surname;
            existingUser.DisplayName = userDTO.DisplayName;
            existingUser.Country = userDTO.Country;
            existingUser.UpdatedAt = DateTime.UtcNow;

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
    public async Task<(bool isSuccessfull, string errorMessage)> CreateContactRequest(string senderUserObjectId, string receiverUserObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var existingContactRequest = await dbContext.ContactRequests
                .AsNoTracking()
                .FirstOrDefaultAsync(cr =>
                    cr.SenderUserObjectId == senderUserObjectId && cr.ReceiverUserObjectId == receiverUserObjectId);

            if (existingContactRequest != null)
            {
                return (false, "You have already sent a contact request to that person");
            }

            var contactRequest = new ContactRequest()
            {
                SenderUserObjectId = senderUserObjectId,
                ReceiverUserObjectId = receiverUserObjectId,
            };

            await dbContext.ContactRequests.AddAsync(contactRequest).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create contact request");
            return (false, "Something went wrong while trying to send contact request. Try again later");
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
    /// Deletes the contact between the primary user and the contact asynchronously
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
                .FirstOrDefault(contact => 
                    (contact.UserObjectId == primaryUserObjectId && contact.ContactObjectId == contactToDeleteUserObjectId) ||
                    (contact.UserObjectId == contactToDeleteUserObjectId && contact.ContactObjectId == primaryUserObjectId));

            if (contact == null) return false;

            dbContext.Contacts.Remove(contact);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

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
}
