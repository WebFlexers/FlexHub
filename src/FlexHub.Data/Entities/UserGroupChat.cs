namespace FlexHub.Data.Entities;

public class UserGroupChat
{
    public string UserObjectId { get; set; }
    public User User { get; set; }

    public int GroupChatId { get; set; }
    public GroupChat GroupChat { get; set; }
}
