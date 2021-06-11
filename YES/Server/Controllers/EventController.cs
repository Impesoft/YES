using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Business.Services;
using YES.Shared.Dto;

namespace YES.Server.Controllers
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

        [HttpPost]
        public async Task<ActionResult> AddEvent(EventDto eventDto)
        {
            return Ok(await _eventService.AddEventAsync(eventDto));            
        }

    }
}
