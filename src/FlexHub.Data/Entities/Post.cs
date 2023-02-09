namespace FlexHub.Data.Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<PostTag> PostsTags { get; set; }

    public string UserObjectId { get; set; }
    public User User { get; set; }
}
