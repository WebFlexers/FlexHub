using FlexHub.Data.DTOs;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface ITagRepository
{
    /// <summary>
    /// Gets all the tags
    /// </summary>
    Task<List<TagDTO>?> GetAllTags();

    /// <summary>
    /// Gets all the tags that the user has subscribed to asynchronously
    /// </summary>
    Task<List<TagDTO>?> GetUserTags(string userObjectId);

    /// <summary>
    /// Subscribes the given tag to the given user
    /// </summary>
    Task<bool> SubscribeTagToUser(string userObjectId, int tagId);

    /// <summary>
    /// Unsubscribes the given tag from the given user
    /// </summary>
    Task<bool> UnsubscribeTagFromUser(string userObjectId, int tagId);
}