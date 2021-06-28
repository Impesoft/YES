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
            message += @"<p style=""color: #ffc107;""><b>Y</bold>our <b>E</bold>vent <b>S</b>ervice</p> <br><br>";

            message += @"
                            <svg viewBox=""0 0 409.47765904521555 120.77193848215795"">
                                <defs></defs>
                                <g
                                   featurekey=""symbolFeature-0""
                                   transform=""matrix(1.457006032620896,0,0,-1.457006032620896,51.986466820585065,117.32494489552775)""
                                   fill=""#ffc107"">
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M7,47c-0.829,0-1.5,0.671-1.5,1.5v3C5.5,52.329,6.171,53,7,53s1.5-0.671,1.5-1.5v-3C8.5,47.671,7.829,47,7,47z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M12.733,41.603c-0.829,0-1.5,0.671-1.5,1.5v13.795c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V43.103  C14.233,42.274,13.562,41.603,12.733,41.603z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M18.467,44.667c-0.829,0-1.5,0.671-1.5,1.5v7.667c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5v-7.667  C19.967,45.338,19.295,44.667,18.467,44.667z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M24.2,36.375c-0.829,0-1.5,0.671-1.5,1.5v24.25c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5v-24.25  C25.7,37.046,25.029,36.375,24.2,36.375z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M29.933,28.833c-0.829,0-1.5,0.671-1.5,1.5v39.333c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V30.333  C31.433,29.505,30.762,28.833,29.933,28.833z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M35.667,37.333c-0.829,0-1.5,0.671-1.5,1.5v22.333c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V38.833  C37.167,38.005,36.495,37.333,35.667,37.333z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M41.534,29.835c-0.87-0.024-1.505,0.662-1.51,1.49l-0.249,37.331c-0.005,0.828,0.662,1.504,1.49,1.51  c0.003,0,0.006,0,0.01,0c0.824,0,1.495-0.665,1.5-1.49l0.249-37.331C43.03,30.517,42.363,29.84,41.534,29.835z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M47.133,20.849c-0.829,0-1.5,0.671-1.5,1.5v55.303c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V22.349  C48.633,21.52,47.962,20.849,47.133,20.849z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M52.867,27.25c-0.829,0-1.5,0.671-1.5,1.5v42.5c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5v-42.5  C54.367,27.921,53.695,27.25,52.867,27.25z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M58.6,37.333c-0.829,0-1.5,0.671-1.5,1.5v22.333c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V38.833  C60.1,38.005,59.429,37.333,58.6,37.333z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M64.333,31c-0.829,0-1.5,0.671-1.5,1.5v35c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5v-35  C65.833,31.671,65.162,31,64.333,31z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M70.067,39.632c-0.829,0-1.5,0.671-1.5,1.5v17.735c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V41.132  C71.567,40.304,70.896,39.632,70.067,39.632z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M75.8,43.5c-0.829,0-1.5,0.671-1.5,1.5v10c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V45  C77.3,44.171,76.628,43.5,75.8,43.5z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M81.533,41.735c-0.829,0-1.5,0.671-1.5,1.5v13.53c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5v-13.53  C83.033,42.406,82.362,41.735,81.533,41.735z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M87.267,45.99c-0.829,0-1.5,0.671-1.5,1.5v5.021c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5V47.49  C88.767,46.661,88.095,45.99,87.267,45.99z""></path>
                                    <path xmlns=""http://www.w3.org/2000/svg"" d=""M93,47.417c-0.829,0-1.5,0.671-1.5,1.5v2.167c0,0.829,0.671,1.5,1.5,1.5s1.5-0.671,1.5-1.5v-2.167  C94.5,48.088,93.829,47.417,93,47.417z""></path>
                                </g>
                                <g featurekey=""nameFeature-0""
                                   transform=""matrix(2.9292202507675666,0,0,2.9292202507675666,197.9942904131483,-50.438220747522585)""
                                   fill=""#ffc107"">
                                    <path d=""M22.832 27.266 l-11.777 19.961 l-9.6875 0 l5.3516 -8.8281 c-0.33203 -3.6328 -0.91797 -7.3633 -1.4844 -11.133 l-1.7773 0 c-0.44922 -3.0859 -0.89844 -6.1914 -1.25 -9.2188 l9.5508 0 l0.78125 8.3398 l0.039063 -0.058594 c0 -0.039063 0.039063 -0.039063 0.039063 -0.097656 c1.4844 -2.7148 2.9102 -5.4297 4.4141 -8.1836 l9.3945 0 l-5.4297 9.2188 l1.8359 0 z M27.3681953125 29.141 c0.15625 -0.66406 0.37109 -1.25 0.56641 -1.875 l-2.168 0 c4.6875 -12.754 24.766 -14.023 22.168 0 l2.1875 0 c-0.039063 0.23438 -0.039063 0.46875 -0.097656 0.72266 l-0.83984 3.2617 l-12.93 0 c-0.66406 4.8242 8.4961 3.3594 9.3945 1.6211 l2.9883 0 l-1.4258 5.5664 c-7.7148 4.4336 -22.715 3.3203 -19.844 -9.2969 z M41.2156953125 25.371000000000002 c0.42969 -2.1289 -4.2578 -3.3398 -6.4648 0 c0.019531 0 6.4648 0.019531 6.4648 0 z M70.18592187499999 27.266 c1.582 1.2109 2.1484 2.9883 1.582 5.4297 c-1.8945 8.4961 -14.297 9.4141 -20.898 5.6641 l1.582 -6.7578 l2.6563 0 c0.29297 1.6016 3.2422 3.2227 6.1719 2.5195 c1.8164 -0.48828 1.1133 -1.1328 -0.13672 -1.4844 c-1.8555 -0.50781 -4.8242 -0.27344 -6.6992 -3.2422 c-0.37109 -0.60547 -0.56641 -1.4063 -0.60547 -2.1289 l-1.8359 0 c-0.11719 -1.7969 0.60547 -3.6914 1.582 -5.0195 c4.1602 -5.4297 12.832 -5.9375 18.613 -2.8125 l-1.4258 6.1328 l-2.7344 0 c-0.78125 -1.3477 -5.0781 -2.6172 -6.2695 -1.5625 c-0.41016 0.41016 -0.13672 1.1328 1.9336 1.5234 c0.82031 0.15625 1.7383 0.33203 2.5391 0.60547 c0.83984 0.33203 1.543 0.70313 2.1289 1.1328 l1.8164 0 z""></path>
                                </g>
                                <g featurekey=""sloganFeature-0""
                                   transform=""matrix(1.5813844492469984,0,0,1.5813844492469984,89.68372265771288,88.827971400868)""
                                   fill=""#ffc107"">
                                    <path d=""M6.4 15.7 l0 4.3 l-1.5 0 l0 -4.3 l-4.7 -9.1 l0 -0.6 l1.5 0 l3.9 8.1 l0.1 0 l3.9 -8.1 l1.5 0 l0 0.6 z M12.9 16.9 l0 -7.8 c0 -1.9 1.4 -3.3 3.5 -3.3 l3.5 0 c2.1 0 3.5 1.4 3.5 3.3 l0 7.8 c0 1.9 -1.4 3.3 -3.5 3.3 l-3.5 0 c-2.1 0 -3.5 -1.4 -3.5 -3.3 z M21.9 16.9 l0 -7.8 c0 -1.1 -0.9 -2 -2 -2 l-3.5 0 c-1.1 0 -2 0.9 -2 2 l0 7.8 c0 1.1 0.9 2 2 2 l3.5 0 c1.1 0 2 -0.9 2 -2 z M33.5 20.2 l-3 0 c-2.1 0 -3.5 -1.4 -3.5 -3.3 l0 -10.9 l1.5 0 l0 10.9 c0 1.1 0.9 2 2 2 l3 0 c1.1 0 2 -0.9 2 -2 l0 -10.9 l1.5 0 l0 10.9 c0 1.9 -1.4 3.3 -3.5 3.3 z M42.5 20 l-1.5 0 l0 -14 l6.2 0 c2.1 0 3.5 1.4 3.5 3.3 l0 1.9 c0 2.8 -2.7 3.2 -2.7 3.2 l3.1 5 l0 0.6 l-1.5 0 l-3.1 -5.5 l-4 0 l0 5.5 z M47.2 7.300000000000001 l-4.7 0 l0 5.9 l4.7 0 c1.1 0 2 -0.9 2 -2 l0 -1.9 c0 -1.1 -0.9 -2 -2 -2 z M58.9 20 l0 -14 l9.1 0 l0 0.9 l-0.4 0.4 l-7.2 0 l0 4.9 l5.7 0 l0 1.3 l-5.7 0 l0 5.2 l7.6 0 l0 1.3 l-9.1 0 z M74.39999999999999 18.2 l0.1 0 l4 -12.2 l1.5 0 l0 0.6 l-4.6 13.4 l-1.9 0 l-4.6 -13.4 l0 -0.6 l1.5 0 z M82.3 20 l0 -14 l9.1 0 l0 0.9 l-0.4 0.4 l-7.2 0 l0 4.9 l5.7 0 l0 1.3 l-5.7 0 l0 5.2 l7.6 0 l0 1.3 l-9.1 0 z M102.2 20 l-6.8 -11.5 l-0.1 0 l0.2 2.6 l0 8.9 l-1.5 0 l0 -14 l1.6 0 l6.8 11.5 l0.1 0 l-0.2 -2.6 l0 -8.9 l1.5 0 l0 14 l-1.6 0 z M111.89999999999999 7.300000000000001 l0 12.7 l-1.5 0 l0 -12.7 l-4.4 0 l0 -1.3 l10.3 0 l0 0.9 l-0.4 0.4 l-4 0 z M122.1 9.9 l0 -0.6 c0 -1.9 1.4 -3.3 3.5 -3.3 l5.5 0 l0 0.9 l-0.4 0.4 l-5.1 0 c-1.1 0 -2 0.9 -2 2 l0 0.6 c0 1.1 0.6 1.68 1.6 1.9 l3.7 0.8 c1.4 0.3 2.5 1.4 2.5 3.2 l0 0.9 c0 1.9 -1.4 3.3 -3.5 3.3 l-6 0 l0 -1.3 l6 0 c1.1 0 2 -0.9 2 -2 l0 -0.9 c0 -1.1 -0.6 -1.68 -1.6 -1.9 l-3.7 -0.8 c-1.4 -0.3 -2.5 -1.4 -2.5 -3.2 z  M134.3 20 l0 -14 l9.1 0 l0 0.9 l-0.4 0.4 l-7.2 0 l0 4.9 l5.7 0 l0 1.3 l-5.7 0 l0 5.2 l7.6 0 l0 1.3 l-9.1 0 z M147.5 20 l-1.5 0 l0 -14 l6.2 0 c2.1 0 3.5 1.4 3.5 3.3 l0 1.9 c0 2.8 -2.7 3.2 -2.7 3.2 l3.1 5 l0 0.6 l-1.5 0 l-3.1 -5.5 l-4 0 l0 5.5 z M152.2 7.300000000000001 l-4.7 0 l0 5.9 l4.7 0 c1.1 0 2 -0.9 2 -2 l0 -1.9 c0 -1.1 -0.9 -2 -2 -2 z M162.9 18.2 l0.1 0 l4 -12.2 l1.5 0 l0 0.6 l-4.6 13.4 l-1.9 0 l-4.6 -13.4 l0 -0.6 l1.5 0 z M172.29999999999998 20 l-1.5 0 l0 -14 l1.5 0 l0 14 z M185.2 18.7 l0 1.3 l-5.8 0 c-2.1 0 -3.5 -1.4 -3.5 -3.3 l0 -7.4 c0 -1.9 1.4 -3.3 3.5 -3.3 l5.8 0 l0 0.9 l-0.4 0.4 l-5.4 0 c-1.1 0 -2 0.9 -2 2 l0 7.4 c0 1.1 0.9 2 2 2 l5.8 0 z M187.89999999999998 20 l0 -14 l9.1 0 l0 0.9 l-0.4 0.4 l-7.2 0 l0 4.9 l5.7 0 l0 1.3 l-5.7 0 l0 5.2 l7.6 0 l0 1.3 l-9.1 0 z""></path>
                                </g>
                            </svg>";

            return message;
        }
    }
}
