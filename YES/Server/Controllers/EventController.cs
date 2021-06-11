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
        public async Task<IEnumerable<EventDto>> GetAllUserTradeItems()
        {
            var test = await _eventService.GetEventsAsync();

            return test;
        }

    }
}
