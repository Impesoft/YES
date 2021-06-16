using System.Collections.Generic;
using System.Threading.Tasks;
using YES.API.Data.Entities;

namespace YES.API.Data.Repos
{
    public interface IEventRepo : IGenericRepo<Event>
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
    }
}