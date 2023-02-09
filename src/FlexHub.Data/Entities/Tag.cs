namespace FlexHub.Data.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Value { get; set; }

    public List<PostTag> PostsTags { get; set; }
}
