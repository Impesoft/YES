using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Entities;

namespace YES.Server.Data.Repos
{
    public interface IEventRepo : IGenericRepo<Event>
    {
        Task<IEnumerable<Event>> GetEventsAsync();
    }
}