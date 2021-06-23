using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync();
        Task<EventDto> GetEventByIdAsync(int id);
        Task<IEnumerable<EventDto>> GetEventSpotlightsAsync();
        Task<bool> CreateNewEventAsync(EventDto eventDto);
        Task<IEnumerable<VenueDto>> GetVenuesAsync();
    }
}