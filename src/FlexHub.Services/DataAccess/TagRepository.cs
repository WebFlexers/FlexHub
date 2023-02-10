using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class TagRepository
{
    private readonly ILogger<TagRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public TagRepository(ILogger<TagRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets all the tags that the user has subscribed to asynchronously
    /// </summary>
    public async Task<List<TagDTO>> GetUserTags(string userObjectId)
    {
        throw new NotImplementedException();
    }
}
