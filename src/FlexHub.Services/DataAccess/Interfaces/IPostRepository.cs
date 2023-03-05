using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface IPostRepository
{
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
    Task<List<PostDTO>?> GetPaginatedPostsSortedByPreferredTags(List<Tag>? preferredTags, int pageNumber, int numberOfPostsToLoad);

    /// <summary>
    /// Gets the posts that contain the given title paginated and asynchronously
    /// </summary>
    Task<List<PostDTO>?> GetPaginatedPostsFilteredByTitle(string title, int pageNumber, int numberOfPostsToLoad);

    /// <summary>
    /// Gets the posts that have all the given tags paginated and asynchronously.
    /// </summary>
    Task<List<PostDTO>?> GetPaginatedPostsFilteredByTags(List<Tag> tags, int pageNumber, int numberOfPostsToLoad);

    /// <summary>          
    /// Gets the posts that contain the given title and
    /// have all the given posts paginated and asynchronously
    /// </summary>
    Task<List<PostDTO>?> GetPaginatedPostsFilteredByTitleAndTags(string title, List<Tag> tags, int pageNumber, int numberOfPostsToLoad);

    /// <summary>
    /// Creates a post for the user with the given user object id.
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    Task<bool> CreatePost(CreatePostDTO postDTO);
}