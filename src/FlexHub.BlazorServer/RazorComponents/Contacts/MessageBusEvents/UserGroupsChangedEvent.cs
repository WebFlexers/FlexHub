using FlexHub.Data.DTOs;

namespace FlexHub.BlazorServer.RazorComponents.Contacts.MessageBusEvents;

public class UserGroupsChangedEvent
{
    public GroupChangeType GroupChangeType { get; set; }
    public GroupChatDTO GroupChat { get; set; }
}
