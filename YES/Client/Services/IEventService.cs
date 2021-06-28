using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync();
        Task<EventDto> GetEventByIdAsync(int id);
        Task<IEnumerable<EventDto>> GetEventSpotlightsAsync();
        Task<HttpResponseMessage> CreateNewEventAsync(EventDto eventDto);
        Task<HttpResponseMessage> UpdateEventAsync(EventDto eventDto);
        Task<IEnumerable<VenueDto>> GetVenuesAsync();
        Task<IEnumerable<EventDto>> GetEventsByProviderIdAsync(int id);
    }
}