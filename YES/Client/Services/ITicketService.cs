using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTicketsByUserIdAsync(int id);
        Task<HttpResponseMessage> AddNewTicketsAsync(List<TicketPurchaseDto> tickets);
        Task<HttpResponseMessage> CancelTicketsAsync(List<int> ticketsToCancel);
    }
}