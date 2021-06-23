namespace YES.Api.Business.Services
{
    public interface IEmailService
    {
        bool SendEmail(string eMailreceiver, string nameReceiver, string eMailSubject, string messageToSendInHtml);
    }
}