using TaskMasterApi.Data.Models;
using TaskMasterApi.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace TaskMasterApi.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly GmailSettings _gmailsettings;
        private readonly Settings _settings;

        public SendEmailService(IOptions<GmailSettings> gmailsettings, IOptions<Settings> settings)
        {
            _gmailsettings = gmailsettings.Value;
            _settings = settings.Value;
        }

        public void SendEmail(SendEmailRequest request)
        {
            var fromEmail = _gmailsettings.Username;
            var pasword = _gmailsettings.Pasword;

            var email = new MailMessage();
            email.From = new MailAddress(fromEmail);
            email.Subject = request.subject;
            email.To.Add(new MailAddress(request.to));
            email.Body = request.body;
            email.IsBodyHtml = true;

            if (request.file != null){
                string path = Path.Combine(_settings.SaveDocumentsPath, request.file);
                
                if (File.Exists(path))
                {
                    email.Attachments.Add(new Attachment(path));
                }
            }

            var smtpClient = new SmtpClient("smtp.gmail.com"){
                Port = _gmailsettings.Port,
                Credentials = new NetworkCredential(fromEmail, pasword),
                EnableSsl = true
            };

            smtpClient.Send(email);
        }
    }
}
