namespace FlexHub.Data.Entities;

public class GroupMessage
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }

    public string SenderUserObjectId { get; set; }
    public User SenderUser { get; set; }

    public int GroupChatId { get; set; }
    public GroupChat GroupChat { get; set; }
}
