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

            message += $"<h1>Beste {customer.FirstName} {customer.LastName}</h1> <br>";
            message += "<h2>Het Yes-team bedankt u voor u aankoop</h2>";
            message += "<h4>Onderstaand kan u je factuur terug vinden</h4> <br><br>";

            message += $"<h1>{theEvent.EventInfo.Name}</h1>";
            message += $"<h4>{theEvent.EventInfo.EventDate}</h4> <br><br>";

            foreach (var ticket in tickets)
            {
                message += $"<h3>Ticket: {ticket.TicketCategory.Name} | Prijs/st:  {ticket.TicketCategory.Price} Euro | Aantal: {ticket.Amount}</h3>";
            }

            message += "<br>";

            message += @"<h4> Met vriendelijke groeten</h4>";
            message += @"<h1 style=""color: red;"">Your Event Service</h1> <br><br>";


            return message;
        }
    }
}
