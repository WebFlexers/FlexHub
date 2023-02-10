using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class PostRepository
{
    private readonly ILogger<PostRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public PostRepository(ILogger<PostRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets the posts paginated and sorted by the number
    /// of tags that are provided asynchronously.
    /// For example, if science and philosophy are selected,
    /// then the posts that contain these tags should come up first.
    /// After that the posts that contain at least one of the tags and so on
    /// </summary>
    /// <param name="pageNumber">The page number</param>
    /// <param name="numberOfPostsToLoad">The number of posts to load in a single request</param>
    /// <param name="preferredTags">The list of tags to sort by</param>
    public async Task<List<PostDTO>> GetPaginatedPostsSortedByPreferredTags(List<Tag> preferredTags, int pageNumber, int numberOfPostsToLoad)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the posts that contain the given title paginated and asynchronously
    /// </summary>
    public async Task<List<PostDTO>> GetPaginatedPostsFilteredByTitle(string title, int pageNumber, int numberOfPostsToLoad)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the posts that have all the given tags paginated and asynchronously.
    /// </summary>
    public async Task<List<PostDTO>> GetPaginatedPostsFilteredByTags(List<string> tags, int pageNumber, int numberOfPostsToLoad)
    {
        throw new NotImplementedException();
    }

    /// <summary>          
    /// Gets the posts that contain the given title and
    /// have all the given posts paginated and asynchronously
    /// </summary>
    public async Task<List<PostDTO>> GetPaginatedPostsFilteredByTitleAndTags(string title, List<string> tags, int pageNumber, int numberOfPostsToLoad)
    {
        throw new NotImplementedException(); 
    }

    /// <summary>
    /// Creates a post for the user with the given user object id.
    /// </summary>
    public async Task CreatePost(CreatePostDTO postDTO)
    {
        throw new NotImplementedException();  
    }
}
