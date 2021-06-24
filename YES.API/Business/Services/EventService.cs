using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;
using YES.Shared.Dto;
using YES.Shared.Enums;

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
            IEnumerable<EventDto> eventDtos = _mapper.Map<IEnumerable<EventDto>>(events);
            foreach (var eventDto in eventDtos)
            {
                UpdateAvailableTickets(eventDto);
                UpdateStatus(eventDto);                
            }
            var test = eventDtos;
            return eventDtos;
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            EventDto eventDto = _mapper.Map<EventDto>(await _eventRepo.GetEventByIdAsync(id));
            UpdateAvailableTickets(eventDto);
            UpdateStatus(eventDto);
            return eventDto;
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

        public async Task<IEnumerable<VenueDto>> GetAllVenuesAsync()
        {
            return _mapper.Map<IEnumerable<VenueDto>> (await _eventRepo.GetAllVenues());
        }

        private EventDto UpdateAvailableTickets(EventDto eventDto)
        {
            foreach (var ticketCategory in eventDto.TicketCategories)
            {
                int soldTickets = _ticketService.GetAmountOfSoldTickets(eventDto.Id, ticketCategory.Id);
                ticketCategory.AvailableAmount = ticketCategory.MaxAmount - soldTickets;
            }
            return eventDto;
        }

        private EventDto UpdateStatus(EventDto eventDto)
        {
            if (eventDto.EventInfo.EventDate.Date < DateTime.Now.Date)
            {
                eventDto.Status = Status.Completed.ToString();
            }

            int soldOutCategories = 0;

            foreach (var ticketCategory in eventDto.TicketCategories)
            {
                if (ticketCategory.AvailableAmount <= 0)
                {
                    soldOutCategories++;
                }
            }
            if (soldOutCategories == eventDto.TicketCategories.Count)
            {
                eventDto.Status = Status.SoldOut.ToString();
            }
            return eventDto;            
        }
    }
}
