using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IEmailService _emailService;
        private readonly ITicketCustomerRepo _ticketCustomerRepo;
        private readonly IEventRepo _eventRepo;

        public InvoiceService(IEmailService emailService, ITicketCustomerRepo ticketCustomerRepo, IEventRepo eventRepo)
        {
            _emailService = emailService;
            _ticketCustomerRepo = ticketCustomerRepo;
            _eventRepo = eventRepo;
        }

        public async Task SendInvoiceAsync(IEnumerable<TicketPurchaseDto> ticketPurchaseDtos)
        {
            List<TicketPurchaseDto> tickets = ticketPurchaseDtos.ToList();
            int eventId = tickets[0].EventId;
            int customerId = tickets[0].TicketCustomerId;

            TicketCustomer customer = await _ticketCustomerRepo.GetEntityAsync(customerId);
            Event theEvent = await _eventRepo.GetEventByIdAsync(eventId);

            string body = CreateInvoiceBody(tickets, customer, theEvent);

            _emailService.SendEmail("yes.youreventservice@gmail.com", "John", "Thank you", body);
        }

        private string CreateInvoiceBody(List<TicketPurchaseDto> tickets, TicketCustomer customer, Event theEvent)
        {
            string message = "";

            message += $"<h1>Beste {customer.FirstName} {customer.LastName}</h1> <br><br>";
            message += "<h4>Het Yes-team bedankt u voor u aankoop</h4> <br>";
            message += "<h4>Onderstaand kan u je factuur terug vinden</h4> <br><br>";

            message += $"<h1>{theEvent.EventInfo.Name}</h1>";
            message += $"<h5>{theEvent.EventInfo.EventDate}</h15> <br><br>";

            foreach (var ticket in tickets)
            {
                message += $"<h2>{ticket.TicketCategory.Name} {ticket.TicketCategory.Price} {ticket.Amount}</h2>";
            }

            message += "<br><br>";

            message += "<h4>Met vriendelijke groeten</h4> <br>";
            message += "<h1>Your Event Service</h1> <br><br>";

            return message;
        }
    }
}
