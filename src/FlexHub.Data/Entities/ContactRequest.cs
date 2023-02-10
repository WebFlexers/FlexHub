namespace FlexHub.Data.Entities;

public class ContactRequest
{
    public string SenderUserObjectId { get; set; }
    public User SenderUser { get; set; }

    public string ReceiverUserObjectId { get; set; }
    public User ReceiverUser { get; set; }
}
