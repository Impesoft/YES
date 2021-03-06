using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Business.Services;
using YES.Shared.Dto;

namespace YES.Api.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }        
        
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEvents()
        {
            return Ok(await _eventService.GetEventsAsync());           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEventByIdAsync(int id)
        {
            return Ok(await _eventService.GetEventByIdAsync(id));
        }

        [Authorize(Roles = "TicketProvider")]
        [HttpGet("Provider/{id}")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventByProviderIdAsync(int id)
        {
            return Ok(await _eventService.GetEventsByProviderIdAsync(id));
        }

        [Authorize(Roles = "TicketProvider")]
        [HttpPost]
        public async Task<ActionResult> AddEvent(EventDto eventDto)
        {
            if (await _eventService.AddEventAsync(eventDto))
            {
                return Ok("Event added successfully"); 
            }
            return StatusCode(500, "Failed to add event");
        }

        [Authorize(Roles = "TicketProvider")]
        [HttpPut]
        public async Task<ActionResult> UpdateEvent(EventDto eventDto)
        {
            if (await _eventService.UpdateEventAsync(eventDto))
            {
                return Ok("Event updated successfully");
            }
            return StatusCode(500, "Failed to update event");
        }

        [Authorize(Roles = "TicketProvider")]
        [HttpGet("Venues")]
        public async Task<ActionResult<IEnumerable<VenueDto>>> GetAllVenues()
        {
            return Ok(await _eventService.GetAllVenuesAsync());
        }
    }
}
