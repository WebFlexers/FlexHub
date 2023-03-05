namespace FlexHub.BlazorServer.Models;

public class GroupMessageModel
{
    public int Id { get; set; }
    public bool IsSentByTheLoggedInUser { get; set; }
    public string SenderDisplayName { get; set; }
    public string CreatedAt { get; set; }
    public string Message { get; set; }
}
