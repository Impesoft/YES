using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync();
        Task<EventDto> GetEventByIdAsync(int id);
        Task<bool> AddEventAsync(EventDto eventDto);
        Task<bool> UpdateEventAsync(EventDto eventDto);
        Task<IEnumerable<VenueDto>> GetAllVenuesAsync();
    }
}