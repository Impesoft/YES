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

            message += @"<h1 style=""color: #ffc107; text-decoration: underline;""><b>Y</b>our <b>E</b>vent <b>S</b>ervice</h1> <br>";
            message += $@"<p style=""color: #212529;"">Beste {customer.FirstName} {customer.LastName}</p> <br>";
            message += @"<p style=""color: #212529;"">Het Yes-team bedankt u voor u aankoop</p>";
            message += @"<p style=""color: #212529;"">Onderstaand kan u je factuur terug vinden</p> <br><br>";

            message += $@"<h2 style=""color: #212529;"">{theEvent.EventInfo.Name}</h2>";
            message += $@"<h2 style=""color: #212529;"">{theEvent.EventInfo.EventDate}</h2> <br><br>";

            foreach (var ticket in tickets)
            {
                message += $@"<h3 style=""color: #212529;""><b>Ticket:</b> {ticket.TicketCategory.Name} | <b>Prijs/st:</b>  {ticket.TicketCategory.Price} Euro | <b>Aantal:</b> {ticket.Amount}</h3>";
            }

            message += "<br>";

            message += @"<p style=""color: #212529;"">Met vriendelijke groeten</p>";
            message += @"<img src=""https://raw.githubusercontent.com/Impesoft/YES/Release_2/YES/Client/wwwroot/images/yes-logo.png?token=ABZY4OTACNN5NACCF7BJMNLA3HI5W"" width=""300px"">";

            return message;
        }
    }
}
