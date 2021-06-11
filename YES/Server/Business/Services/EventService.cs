using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Entities;
using YES.Server.Data.Repos;
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

    }
}
