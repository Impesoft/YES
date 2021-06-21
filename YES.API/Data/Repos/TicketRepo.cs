using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YES.Api.Data.Database;
using YES.Api.Data.Entities;

namespace YES.Api.Data.Repos
{
    public class TicketRepo : GenericRepo<Ticket>, ITicketRepo
    {
        public TicketRepo(YesDBContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Ticket>> GetTicketsForEvent(int eventId)
        {
            return await _context.Tickets
                                   .Where(x => x.EventId == eventId)
                                   .ToListAsync();
        }

        public int GetCountOfTicketsForEvent(int eventId, int categoryId)
        {
            return _context.Tickets.Where(x => x.EventId == eventId)
                                   .Count(x => x.TicketCategoryId == categoryId);                                   
        }
    }
}
