using System;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Demo.Domain.Services {

    public interface IEmailService {

        void Send(string email, string subject, string body);
    }

    public class EmailService : IEmailService {

        private readonly SmtpClient _smtpClient;
        private readonly MailSettingsSectionGroup _mailSettings;

        public EmailService() {
            var configuration = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            _mailSettings = configuration.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
            if (_mailSettings == null) throw new Exception();

            _smtpClient = new SmtpClient {
                Host = _mailSettings.Smtp.Network.Host,
                Port = _mailSettings.Smtp.Network.Port,
                EnableSsl = _mailSettings.Smtp.Network.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailSettings.Smtp.Network.UserName, _mailSettings.Smtp.Network.Password)
            };
        }

        public void Send(string email, string subject, string body) {
            var from = new MailAddress(_mailSettings.Smtp.Network.UserName);
            var to = new MailAddress(email);
            using (var message = new MailMessage(from, to)) {
                message.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                message.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.Body = body;

                _smtpClient.Send(message);
            }
        }
    }
}
