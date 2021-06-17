using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepo _eventRepo;
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public EventService(IEventRepo eventRepo, ITicketService ticketService, IMapper mapper)
        {
            _eventRepo = eventRepo;
            _ticketService = ticketService;
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
            EventDto eventDto = _mapper.Map<EventDto>(await _eventRepo.GetEventByIdAsync(id));
            return await UpdateAvailableTickets(eventDto);
        }

        private async Task<EventDto> UpdateAvailableTickets(EventDto eventDto)
        {
            foreach (var ticketCategory in eventDto.TicketCategories)
            {
                int soldTickets = await _ticketService.GetAmountOfSoldTickets(eventDto.Id, ticketCategory.Id);
                ticketCategory.AvailableAmount = ticketCategory.MaxAmount - soldTickets;
            }
            return eventDto;
        }
    }
}
