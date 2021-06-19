using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;

namespace YES.Api.Data.Repos
{
    public interface ITicketProviderRepo : IGenericRepo<TicketProvider>
    {
        Task<IEnumerable<TicketProvider>> GetAllTicketProvidersAsync();
        Task<TicketProvider> GetTicketProviderByEmailAsync(string email);
    }
}