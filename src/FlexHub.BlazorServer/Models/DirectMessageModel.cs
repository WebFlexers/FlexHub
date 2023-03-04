namespace FlexHub.BlazorServer.Models;

public class DirectMessageModel
{
    public bool IsSentByTheLoggedInUser { get; set; }
    public string CreatedAt { get; set; }
    public string Message { get; set; }
}
