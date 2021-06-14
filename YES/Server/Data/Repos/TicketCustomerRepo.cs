using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using YES.Server.Data.Database;
using YES.Server.Data.Entities;

namespace YES.Server.Data.Repos
{
    public class TicketCustomerRepo : GenericRepo<TicketCustomer>, ITicketCustomerRepo
    {
        public TicketCustomerRepo(YesDBContext context) : base(context)
        {
        }

        override public async Task<TicketCustomer> GetEntityAsync(int id)
        {
            return await _context.TicketCustomers
                                 .Include(x => x.Address)
                                 .Include(x => x.Tickets)
                                 .ThenInclude(x => x.TicketPrice)
                                 .Include(x => x.Tickets)
                                 .ThenInclude(x => x.Event)
                                 .ThenInclude(x => x.EventInfo)
                                 .Include(x => x.Tickets)
                                 .ThenInclude(x => x.Event)
                                 .ThenInclude(x => x.Venue)
                                 .ThenInclude(x => x.Address)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
