using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Entities;
using YES.Server.Data.Repos;
using YES.Server.Enums;
using YES.Shared.Dto;

namespace YES.Server.Business.Services
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
            eventToAdd.Id = 0;

            System.Enum.TryParse(eventDto.Status, out Status myStatus);
            eventToAdd.Status = myStatus;

            bool succes = await _eventRepo.AddEntityAsync(eventToAdd);
            return succes;
        }
    }
}
