using FlexHub.Data;
using FlexHub.Data.DTOs;
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
}
