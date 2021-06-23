namespace YES.Api.Business.Services
{
    public interface IEmailService
    {
        void SendEmail(string eMailreceiver, string nameReceiver, string eMailSubject, string messageToSendInHtml);
    }
}