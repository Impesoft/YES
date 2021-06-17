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
        private ITicketRepo _ticketRepo;
        public TicketService(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public async Task<bool> BuyTickets(IEnumerable<TicketPurchaseDto> ticketPurchaseDtos)
        {
            List<Ticket> tickets = new();

            foreach (var item in ticketPurchaseDtos)
            {
                for (int i = 0; i < item.Amount; i++)
                {
                    tickets.Add(CreateTicket(item));
                }
            }

            return await _ticketRepo.AddEntitiesAsync(tickets);
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

        public async Task<int> GetAmountOfSoldTickets(int eventId, int TicketCategoryId)
        {
            int amount = 0;
            IEnumerable<Ticket> tickets = await _ticketRepo.GetTicketsForEvent(eventId);

            foreach (var ticket in tickets)
            {
                if (ticket.TicketCategory.Id == TicketCategoryId)
                {
                    amount++;
                }
            }
            return amount;
        }
    }
}
