namespace TaskMasterApi.Api;
public interface INotificationClient
{
    Task RecibeNotification(string messge);
}