using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class TagRepository : EfCoreRepositoryBase, ITagRepository
{
    private readonly ILogger<TagRepository> _logger;

    public TagRepository(ILogger<TagRepository> logger, IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets all the tags
    /// </summary>
    public async Task<List<TagDTO>?> GetAllTags()
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var tags = await dbContext.Tags
                .AsNoTracking()
                .Select(tag => new TagDTO { Id = tag.Id, Value = tag.Value })
                .ToListAsync();

            return tags;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch user tags");
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Gets all the tags that the user has subscribed to asynchronously
    /// </summary>
    public async Task<List<TagDTO>?> GetUserTags(string userObjectId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            return await dbContext.UsersTags
               .Where(userTag => userTag.UserObjectId == userObjectId)
               .Select(userTag => new TagDTO { Id = userTag.TagId, Value = userTag.Tag.Value })
               .ToListAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch user tags");
            return default;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Subscribes the given tag to the given user
    /// </summary>
    public async Task<bool> SubscribeTagToUser(string userObjectId, int tagId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            await dbContext.UsersTags.AddAsync(new UserTag
            {
                TagId = tagId,
                UserObjectId = userObjectId
            });

            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to subscribe to tag with id {tagId} to user {userObjectId}", tagId, userObjectId);
            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }

    /// <summary>
    /// Unsubscribes the given tag from the given user
    /// </summary>
    public async Task<bool> UnsubscribeTagFromUser(string userObjectId, int tagId)
    {
        ApplicationDbContext? dbContext = null; 
        var createdNewDbContext = false;

        try
        {
            (dbContext, createdNewDbContext) = GetThreadSafeDbContext();

            var userTag = await dbContext.UsersTags
                .FindAsync(userObjectId, tagId);

            if (userTag == null)
            {
                return false;
            }

            dbContext.Remove(userTag);

            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to unsubscribe tag with id {tagId} from user {userObjectId}", tagId, userObjectId);
            return false;
        }
        finally
        {
            await CleanUpAsync(dbContext, createdNewDbContext);
        }
    }
}
