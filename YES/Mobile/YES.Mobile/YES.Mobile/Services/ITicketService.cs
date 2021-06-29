using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public interface ITicketService
    {
        Task<HttpResponseMessage> BuyTicketsAsync(IEnumerable<TicketPurchaseDto> tickets);

        Task<bool> CancelTicketsAsync(List<int> obj);
    }
}