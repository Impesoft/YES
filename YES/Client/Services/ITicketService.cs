using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface ITicketService
    {
        Task AddNewTicketsAsync(List<TicketPurchaseDto> tickets);
        Task<IEnumerable<TicketDto>> GetTicketsByUserIdAsync(int id);
        Task<bool> CancelTicketsAsync(List<int> ticketsToCancel);
    }
}