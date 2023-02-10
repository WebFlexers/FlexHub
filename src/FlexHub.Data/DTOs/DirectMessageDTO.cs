namespace FlexHub.Data.DTOs;

public class DirectMessageDTO
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public string SenderUserObjectId { get; set; }
    public string ReceiverUserObjectId { get; set; }
}
