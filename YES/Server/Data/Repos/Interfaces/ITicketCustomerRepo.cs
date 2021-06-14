using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Entities;

namespace YES.Server.Data.Repos
{
    public interface ITicketCustomerRepo
    {
        Task<TicketCustomer> GetEntityAsync(int id);
    }
}