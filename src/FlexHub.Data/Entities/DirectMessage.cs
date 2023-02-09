namespace FlexHub.Data.Entities;

public class DirectMessage
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }

    public string SenderUserObjectId { get; set; }
    public User SenderUser { get; set; }

    public string ReceiverUserObjectId { get; set; }
    public User ReceiverUser { get; set; }
}
