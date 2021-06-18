using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;

namespace YES.Api.Data.Repos
{
    public interface ITicketRepo : IGenericRepo<Ticket>
    {     
        Task<IEnumerable<Ticket>> GetTicketsForEvent(int eventId);       
    }
}