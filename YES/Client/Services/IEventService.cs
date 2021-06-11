using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Shared;

namespace YES.Client.Services
{
    public interface IEventService
    {
        IEnumerable<EventDTO> GetEvents();
        IEnumerable<EventDTO> GetEventSpotlights();
        Task GetEventsFromAPIAsync();
        void SetEventsTest();
    }
}