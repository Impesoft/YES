using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Database;
using YES.Server.Data.Entities;

namespace YES.Server.Data.Repos
{
    public class EventRepo : GenericRepo<Event>, IEventRepo
    {
        public EventRepo(YesDBContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _context.Events
                                 .Include(x => x.EventInfo)
                                 .Include(x => x.TicketProvider)
                                 .Include(x => x.Venue)
                                 .ThenInclude(x => x.Address)
                                 .ToListAsync();
        }
        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events
                                 .Include(x => x.EventInfo)
                                 .Include(x => x.TicketProvider)
                                 .Include(x => x.Venue)
                                 .ThenInclude(x => x.Address)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
