namespace TaskMasterApi.Data.Models;

public partial class GmailSettings
{
    public string Username { get; set; } = null!;
    public string Pasword { get; set; } = null!;
    public int Port { get; set; }
}