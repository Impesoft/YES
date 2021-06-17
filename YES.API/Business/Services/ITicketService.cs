using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public interface ITicketService
    {
        Task<bool> BuyTickets(IEnumerable<TicketPurchaseDto> ticketPurchaseDtos);
    }
}