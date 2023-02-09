namespace FlexHub.Data.Entities;

public class Contact
{
    public string UserObjectId { get; set; }
    public User User { get; set; }

    public string ContactObjectId { get; set; }
    public User ContactUser { get; set; }
}
