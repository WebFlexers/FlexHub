namespace FlexHub.Data.DTOs;

public class GroupMessageDTO
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public string SenderUserObjectId { get; set; }
    public string SenderUserDisplayName { get; set; }
    public int GroupChatId { get; set; }
}
