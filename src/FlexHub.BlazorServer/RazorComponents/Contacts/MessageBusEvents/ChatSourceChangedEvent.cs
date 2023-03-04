namespace FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;

/// <summary>
/// The ContactObjectId and GroupChatId will only be filled
/// if the appropriate ChatType is selected for each of them
/// </summary>
public class ChatSourceChangedEvent
{
    public ChatType ChatType { get; set; }
    public string LoggedInUserObjectId { get; set; }
    public string ContactObjectId { get; set; }
    public int GroupChatId { get; set; }
}
