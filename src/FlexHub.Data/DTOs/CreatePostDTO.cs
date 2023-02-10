namespace FlexHub.Data.DTOs;

public class CreatePostDTO
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<TagDTO> Tags { get; set; }
    public string UserObjectId { get; set; }
}