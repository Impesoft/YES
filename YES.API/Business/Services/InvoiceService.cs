namespace YES.Api.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IEmailService _emailService;

        public InvoiceService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool SendInvoice()
        {
            string message = GetInvoiceMessage();
            return _emailService.SendEmail("yes.youreventservice@gmail.com", "John", "Thank you", message);
        }

        private string GetInvoiceMessage()
        {
            string message = "jojo";

            return message;
        }

    }
}
