using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Repos.Interfaces;
using YES.Api.Data.Entities;

namespace YES.Api.Data.Repos.Interfaces
{
    public interface ITicketCustomerRepo : IGenericRepo<TicketCustomer>
    {
        Task<TicketCustomer> GetEntityAsync(int id);
    }
}