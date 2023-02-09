namespace FlexHub.Data.Entities;

public class UserTag
{
    public string UserObjectId { get; set; }
    public User User { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }
}
