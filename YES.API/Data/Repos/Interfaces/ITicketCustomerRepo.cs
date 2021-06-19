using System.Threading.Tasks;
using YES.Api.Data.Entities;

namespace YES.Api.Data.Repos.Interfaces
{
    public interface ITicketCustomerRepo : IGenericRepo<TicketCustomer>
    {
        Task<TicketCustomer> GetEntityAsync(int id);
        Task<bool> DeleteEntityAsync(int id);        
        Task<TicketCustomer> GetTicketCustomerByEmailAsync(string email);
    }
}