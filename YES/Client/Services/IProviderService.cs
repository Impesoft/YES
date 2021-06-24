using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IProviderService
    {
        Task<TicketProviderDto> GetProviderByIdAsync(int id);
        Task UpdateProvider(TicketProviderDto provider);
    }
}