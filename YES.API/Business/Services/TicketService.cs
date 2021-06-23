using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public class TicketService :  ITicketService
    {
        private readonly ITicketRepo _ticketRepo;
        private readonly IInvoiceService _invoiceService;

        public TicketService(ITicketRepo ticketRepo, IInvoiceService invoiceService)
        {
            _ticketRepo = ticketRepo;
            _invoiceService = invoiceService;
        }

        public async Task<bool> BuyTickets(IEnumerable<TicketPurchaseDto> ticketPurchaseDtos, bool sendInvoice)
        {
            List<Ticket> tickets = new();

            foreach (var item in ticketPurchaseDtos)
            {
                for (int i = 0; i < item.Amount; i++)
                {
                    tickets.Add(CreateTicket(item));
                }
            }

            if (await _ticketRepo.AddEntitiesAsync(tickets))
            {
                if (sendInvoice)
                {
                    return _invoiceService.SendInvoice();
                }
                return true;
            }  
            
            return false;
        }

        public async Task<bool> CancelTickets(IEnumerable<int> canceledTicketIds)
        {
            List<Ticket> CancelledTickets = new();

            foreach (var canceledTicketId in canceledTicketIds)
            {
                Ticket ticket = new()
                {
                    Id = canceledTicketId
                };
                CancelledTickets.Add(ticket);
            }
            return await _ticketRepo.DeleteEntitiesAsync(CancelledTickets);
        }

        private Ticket CreateTicket(TicketPurchaseDto ticketPurchaseDto)
        {
            return new()
            {
                Id = 0,
                TicketCustomerId = ticketPurchaseDto.TicketCustomerId,
                EventId = ticketPurchaseDto.EventId,
                TicketCategoryId = ticketPurchaseDto.TicketCategory.Id,
                DateOfPurchase = DateTime.Now
            };
        }

        public int GetAmountOfSoldTickets(int eventId, int TicketCategoryId)
        {           
            return  _ticketRepo.GetCountOfTicketsForEvent(eventId, TicketCategoryId);
        }
    }
}
