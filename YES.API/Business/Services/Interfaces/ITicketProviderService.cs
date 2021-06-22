using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public interface ITicketProviderService
    {        
        Task<bool> DeleteTicketProvider(int id);
        Task<TicketProviderDto> GetTicketProviderByIdAsync(int id);
        Task<bool> UpdateTicketProvider(TicketProviderDto ticketProviderDto);
    }
}