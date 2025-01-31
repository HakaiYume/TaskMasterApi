using Microsoft.AspNetCore.SignalR;

namespace TaskMasterApi.Api;

public class NotificationHub : Hub<INotificationClient>
{
    public override Task OnConnectedAsync()
    {
        Clients.Client(Context.ConnectionId).RecibeNotification($"Esta es una notificacion de confirmacion para {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }
} 