using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;

namespace YES.Api.Data.Repos.Interfaces
{
    public interface IEventRepo : IGenericRepo<Event>
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task<IEnumerable<Event>> GetEventsByIdProviderIdAsync(int id);
        Task<IEnumerable<Venue>> GetAllVenues();
        new Task<bool> AddEntityAsync(Event eventToAdd);
        new Task<bool> UpdateEntityAsync(Event eventToUpdate);
    }
}