namespace FlexHub.Data.Entities;

public class GroupChat
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public HashSet<UserGroupChat> GroupChatsUsers { get; set; }
    public List<GroupMessage> GroupMessages { get; set; }
}
