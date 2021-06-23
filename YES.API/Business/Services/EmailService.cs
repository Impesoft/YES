using System.Net;
using System.Net.Mail;

namespace YES.Api.Business.Services
{
    public class EmailService : IEmailService
    {
        private bool succes = false;

        public bool SendEmail(string eMailreceiver, string nameReceiver, string subject, string messageHtml)
        {
            SmtpClient Client = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "yes.youreventservice@gmail.com",
                    Password = "NoSir1418"
                }
            };
            MailAddress fromEmail = new("yes.youreventservice@gmail.com", "YesTeam");
            MailAddress toEmail = new(eMailreceiver, nameReceiver);
            MailMessage message = new()
            {
                From = fromEmail,
                Subject = subject,
                Body = messageHtml,
                IsBodyHtml = true
            };
            message.To.Add(toEmail);
            Client.SendCompleted += Client_SendCompleted;
            Client.SendMailAsync(message);

            return succes;
        }

        private void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                succes = false;
                return;               
            }
            succes = true;
        }
    }
}
