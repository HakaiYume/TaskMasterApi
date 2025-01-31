
using Microsoft.AspNetCore.SignalR;

namespace TaskMasterApi.Api;

public class ServerNotifier : BackgroundService
{
    private static readonly TimeSpan Periodo = TimeSpan.FromSeconds(1);
    private readonly IHubContext<NotificationHub, INotificationClient> _SRcontext;

    public ServerNotifier(IHubContext<NotificationHub, INotificationClient> sRcontext)
    {
        _SRcontext = sRcontext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var timer = new PeriodicTimer(Periodo))
        {
            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                var dateTime = DateTime.Now;
                await _SRcontext.Clients.All.RecibeNotification(dateTime.ToString());
            };
        }
    }
}