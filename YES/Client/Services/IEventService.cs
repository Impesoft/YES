using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Shared;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetEvents();
        IEnumerable<EventDto> GetEventSpotlights();
        Task<IEnumerable<EventDto>> GetEventsFromAPIAsync();
        void SetEventsTest();
    }
}