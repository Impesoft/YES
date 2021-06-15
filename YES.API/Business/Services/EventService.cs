using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.API.Data.Entities;
using YES.API.Data.Repos;
using YES.Shared.Dto;

namespace YES.API.Business.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepo _eventRepo;
        private readonly IMapper _mapper;

        public EventService(IEventRepo eventRepo, IMapper mapper)
        {
            _eventRepo = eventRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EventDto>> GetEventsAsync()
        {
            IEnumerable<Event> events = await _eventRepo.GetEventsAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<bool> AddEventAsync(EventDto eventDto)
        {
            Event eventToAdd = _mapper.Map<Event>(eventDto);            
            return await _eventRepo.AddEntityAsync(eventToAdd);          
        }
        public async Task<bool> UpdateEventAsync(EventDto eventDto)
        {            
            Event currentEvent = _mapper.Map<Event>(eventDto);
            return await _eventRepo.UpdateEntityAsync(currentEvent);            
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            return _mapper.Map<EventDto>(await _eventRepo.GetEventByIdAsync(id));
        }
    }
}
