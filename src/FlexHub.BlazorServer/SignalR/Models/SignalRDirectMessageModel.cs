namespace FlexHub.BlazorServer.SignalR.Models;

public class SignalRDirectMessageModel
{
    public string SenderDisplayName { get; set; }
    public int DirectMessageId { get; set; }
    public string ReceiverObjectId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; }
}