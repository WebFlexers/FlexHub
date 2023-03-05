using FlexHub.BlazorServer.SignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace FlexHub.BlazorServer.SignalR.Hubs;

public class ChatHub : Hub
{
    public async Task SendDirectMessage(string senderObjectId, SignalRDirectMessageModel dmModel)
    {
        await Clients.All.SendAsync(SignalRMessages.ReceiveDirectMessage, senderObjectId, dmModel);
    }

    public async Task SendGroupMessage(string senderObjectId, SignalRGroupMessageModel groupMessageModel)
    {
        await Clients.All.SendAsync(SignalRMessages.ReceiveGroupMessage, senderObjectId, groupMessageModel);
    }
}
