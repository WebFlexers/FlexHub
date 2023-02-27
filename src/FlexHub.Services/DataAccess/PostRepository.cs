using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using FlexHub.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class PostRepository : IPostRepository
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
    /// After that the posts that contain just one of the tags
    /// and finally the posts that contain neither of these tags
    /// </summary>
    /// <param name="pageNumber">The page number</param>
    /// <param name="numberOfPostsToLoad">The number of posts to load in a single request</param>
    /// <param name="preferredTags">The list of tags to sort by</param>
    public async Task<List<PostDTO>?> GetPaginatedPostsSortedByPreferredTags(List<Tag> preferredTags, int pageNumber, int numberOfPostsToLoad)
    {
        try
        {
            var posts = await _dbContext.Posts
                .AsNoTracking()
                .OrderByDescending(post => post.PostsTags.Count(postTag => preferredTags.Contains(postTag.Tag)))
                .Paginate(pageNumber, numberOfPostsToLoad)
                .Select(post => new PostDTO
                {
                    PostId = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Tags = post.PostsTags.Select(postTag => new TagDTO
                    {
                        Id = postTag.TagId,
                        Value = postTag.Tag.Value
                    }).ToList(),
                    UserObjectId = post.UserObjectId
                })
                .ToListAsync().ConfigureAwait(false);

            return posts;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, "Failed to get paginated posts sorted by preferred tags");
            return default;
        }
    }

    /// <summary>
    /// Gets the posts that contain the given title paginated and asynchronously
    /// </summary>
    public async Task<List<PostDTO>?> GetPaginatedPostsFilteredByTitle(string title, int pageNumber, int numberOfPostsToLoad)
    {
        try
        {
            var posts = await _dbContext.Posts
                .AsNoTracking()
                .Where(post => post.Title.Contains(title))
                .OrderByDescending(post => post.CreatedAt)
                .Paginate(pageNumber, numberOfPostsToLoad)
                .Select(post => new PostDTO
                {
                    PostId = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Tags = post.PostsTags.Select(postTag => new TagDTO
                    {
                        Id = postTag.TagId,
                        Value = postTag.Tag.Value
                    }).ToList(),
                    UserObjectId = post.UserObjectId
                }).ToListAsync().ConfigureAwait(false);

            return posts;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get paginated posts filtered by title");

            return default;
        }
    }

    /// <summary>
    /// Gets the posts that have all the given tags paginated and asynchronously.
    /// </summary>
    public async Task<List<PostDTO>?> GetPaginatedPostsFilteredByTags(List<Tag> tags, int pageNumber, int numberOfPostsToLoad)
    {
        try
        {
            var postIds = await _dbContext.PostsTags
                .AsNoTracking()
                .Where(pt => tags.Contains(pt.Tag))
                .GroupBy(pt => pt.PostId)
                .Where(group => group.Count() == tags.Count)
                .Paginate(pageNumber, numberOfPostsToLoad)
                .Select(group =>  group.Key)
                .ToListAsync();

            if (postIds.Any() == false)
            {
                return default;
            }

            var posts = await _dbContext.Posts
                .Where(post => postIds.Contains(post.Id))
                .Select(post => new PostDTO
                {
                    PostId = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Tags = post.PostsTags.Select(postTag => new TagDTO
                    {
                        Id = postTag.TagId,
                        Value = postTag.Tag.Value
                    }).ToList(),
                    UserObjectId = post.UserObjectId
                })
                .ToListAsync();

            return posts;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, "Failed to get paginated posts filtered by tags");
            return default;
        }

    }

    /// <summary>          
    /// Gets the posts that contain the given title and
    /// have all the given posts paginated and asynchronously
    /// </summary>
    public async Task<List<PostDTO>?> GetPaginatedPostsFilteredByTitleAndTags(string title, List<Tag> tags, int pageNumber, int numberOfPostsToLoad)
    {
        try
        {
            var postIds = await _dbContext.PostsTags
                .AsNoTracking()
                .Where(pt => pt.Post.Title.Contains(title) && 
                                    tags.Contains(pt.Tag))
                .GroupBy(pt => pt.PostId)
                .Where(group => group.Count() == tags.Count)
                .Paginate(pageNumber, numberOfPostsToLoad)
                .Select(group =>  group.Key)
                .ToListAsync();

            if (postIds.Any() == false)
            {
                return default;
            }

            var posts = await _dbContext.Posts
                .Where(post => postIds.Contains(post.Id))
                .Select(post => new PostDTO
                {
                    PostId = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Tags = post.PostsTags.Select(postTag => new TagDTO
                    {
                        Id = postTag.TagId,
                        Value = postTag.Tag.Value
                    }).ToList(),
                    UserObjectId = post.UserObjectId
                })
                .ToListAsync();

            return posts;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, "An error occurred while trying to Get Paginated Posts Filtered By Title And Tags");
            return default;
        }
    }

    /// <summary>
    /// Creates a post for the user with the given user object id.
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> CreatePost(CreatePostDTO postDTO)
    {
        try
        {
            // Create post
            var post = new Post()
            {
                Title = postDTO.Title,
                Content = postDTO.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserObjectId = postDTO.UserObjectId,
            };

            await _dbContext.Posts.AddAsync(post).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            // Create the post tags associated with the above post
            var postTags = new List<PostTag>();
            foreach (var tag in postDTO.Tags)
            {
                postTags.Add(new PostTag() { 
                    PostId = post.Id,                
                    TagId = tag.Id
                });
            }

            await _dbContext.PostsTags.AddRangeAsync(postTags).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, "Failed to create post");
            return false;
        }
    }
}
