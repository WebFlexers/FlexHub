namespace FlexHub.Data.DTOs;

public class PostDTO
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public List<TagDTO> Tags { get; set; }
    public string UserObjectId { get; set; }
}
