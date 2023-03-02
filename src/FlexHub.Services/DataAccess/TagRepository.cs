using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class TagRepository : ITagRepository
{
    private readonly ILogger<TagRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public TagRepository(ILogger<TagRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets all the tags
    /// </summary>
    public async Task<List<TagDTO>?> GetAllTags()
    {
        try
        {
            var tags = await _dbContext.Tags
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
    }

    /// <summary>
    /// Gets all the tags that the user has subscribed to asynchronously
    /// </summary>
    public async Task<List<TagDTO>?> GetUserTags(string userObjectId)
    {
        try
        {
            return await _dbContext.UsersTags
               .Where(userTag => userTag.UserObjectId == userObjectId)
               .Select(userTag => new TagDTO { Id = userTag.TagId, Value = userTag.Tag.Value })
               .ToListAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch user tags");
            return default;
        }
    }
}
