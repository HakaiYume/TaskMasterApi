using TaskMasterApi.Data.Models;
namespace TaskMasterApi.Interfaces
{
    public interface ISendEmailService
    {
        void SendEmail(SendEmailRequest request);
    }
}
