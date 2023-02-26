using FlexHub.Data.DTOs;

namespace FlexHub.Services.DataAccess.Interfaces;

public interface ITagRepository
{
    /// <summary>
    /// Gets all the tags that the user has subscribed to asynchronously
    /// </summary>
    Task<List<TagDTO>> GetUserTags(string userObjectId);
}