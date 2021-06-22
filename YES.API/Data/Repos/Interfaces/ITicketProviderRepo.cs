using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;

namespace YES.Api.Data.Repos
{
    public interface ITicketProviderRepo : IGenericRepo<TicketProvider>
    {
        new Task<bool> DeleteEntityAsync(int id);
        Task<IEnumerable<TicketProvider>> GetAllTicketProvidersAsync();
        new Task<TicketProvider> GetEntityAsync(int id);
        Task<TicketProvider> GetTicketProviderByEmailAsync(string email);
        new Task<bool> UpdateEntityAsync(TicketProvider entity);
    }
}