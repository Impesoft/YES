using System.Threading.Tasks;
using YES.Api.Data.Entities;

namespace YES.Api.Data.Repos.Interfaces
{
    public interface ITicketCustomerRepo : IGenericRepo<TicketCustomer>
    {
        new Task<bool> UpdateEntityAsync(TicketCustomer entity);

        new Task<TicketCustomer> GetEntityAsync(int id);

        new Task<bool> DeleteEntityAsync(int id);

        Task<TicketCustomer> GetTicketCustomerByEmailAsync(string email);
    }
}