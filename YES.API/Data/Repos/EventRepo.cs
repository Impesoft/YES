using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                                 .ThenInclude(x => x.Address)
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
                                 .ThenInclude(x => x.Address)
                                 .Include(x => x.Venue)
                                 .ThenInclude(x => x.Address)
                                 .Include(x => x.TicketCategories)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Event>> GetEventsByIdProviderIdAsync(int id)
        {
            return await _context.Events
                                 .Include(x => x.EventInfo)
                                 .Include(x => x.TicketProvider)
                                 .ThenInclude(x => x.Address)
                                 .Include(x => x.Venue)
                                 .ThenInclude(x => x.Address)
                                 .Include(x => x.TicketCategories)
                                 .Where(x => x.TicketProviderId == id)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Venue>> GetAllVenues()
        {
            return await _context.Venues
                                 .Include(x => x.Address)                                 
                                 .ToListAsync();
        }

        public override async Task<bool> AddEntityAsync(Event eventToAdd)
        {
            if (eventToAdd.Venue != null)
            {
                if (eventToAdd.Venue.Id != 0)
                {
                    eventToAdd.Venue = await _context.Venues.Include(x => x.Address)
                                                        .FirstOrDefaultAsync(x => x.Id == eventToAdd.VenueId);
                }
                
            }
            if (eventToAdd.TicketProvider != null)
            {
                if (eventToAdd.TicketProvider.Id != 0)
                {
                    eventToAdd.TicketProvider = await _context.TicketProviders
                                                          .Include(x => x.Address)
                                                          .FirstOrDefaultAsync(x => x.Id == eventToAdd.TicketProviderId);
                }
                
            }

            _context.Add(eventToAdd);
            await _context.SaveChangesAsync();
            return true;                     
        }

        public override async Task<bool> UpdateEntityAsync(Event eventToUpdate)
        {
            if (eventToUpdate.Venue != null)
            {
                if (eventToUpdate.Venue.Id != 0)
                {
                    eventToUpdate.Venue = await _context.Venues
                                                    .Include(x => x.Address)
                                                    .FirstOrDefaultAsync(x => x.Id == eventToUpdate.VenueId);
                }
            }
            if (eventToUpdate.TicketProvider != null)
            {
                if (eventToUpdate.TicketProvider.Id != 0)
                {
                    eventToUpdate.TicketProvider = await _context.TicketProviders
                                                            .Include(x => x.Address)
                                                            .FirstOrDefaultAsync(x => x.Id == eventToUpdate.TicketProviderId);
                }
            }

            _context.Update(eventToUpdate);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}