using FlexHub.BlazorServer.SignalR.Hubs;

namespace FlexHub.BlazorServer.SignalR;

public static class SignalRMessages
{
    public static string SendDirectMessage => nameof(ChatHub.SendDirectMessage);
    public static string ReceiveDirectMessage => nameof(ReceiveDirectMessage);

    public static string SendGroupMessage => nameof(ChatHub.SendGroupMessage);
    public static string ReceiveGroupMessage => nameof(ReceiveGroupMessage);
}
