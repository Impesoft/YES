using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Database;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;

namespace YES.Api.Data.Repos
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
                                 .Include(x => x.TicketCategories)
                                 .ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events
                                 .Include(x => x.EventInfo)
                                 .Include(x => x.TicketProvider)
                                 .Include(x => x.Venue)
                                 .ThenInclude(x => x.Address)
                                 .Include(x => x.TicketCategories)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Venue>> GetAllVenues()
        {
            return await _context.Venues
                                 .Include(x => x.Address)                                 
                                 .ToListAsync();
        }
    }
}