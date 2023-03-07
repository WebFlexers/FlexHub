namespace FlexHub.BlazorServer.SignalR.Models;

public class SignalRGroupMessageModel
{
    public int GroupId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; }
    public string SenderDisplayName { get; set; }
}
