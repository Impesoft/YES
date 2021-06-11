using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Shared;

namespace YES.Client.Services
{
    public interface IEventService
    {
        ICollection<EventDTO> GetEvents();
        Task GetEventsFromAPIAsync();
        void SetEventsTest();
    }
}