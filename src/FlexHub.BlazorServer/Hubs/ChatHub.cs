using Microsoft.AspNetCore.SignalR;

namespace FlexHub.BlazorServer.Hubs;

public class ChatHub : Hub
{
    public Task SendMessageBetweenTwoUsers(string senderObjectId, string receiverObjectId, string message)
    {
        return Task.CompletedTask;
    }
}
