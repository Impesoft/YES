﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.API.Business.Services;
using YES.Shared.Dto;

namespace YES.API.Controllers
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

        [HttpPost]
        public async Task<ActionResult> AddEvent(EventDto eventDto)
        {
            return Ok(await _eventService.AddEventAsync(eventDto));            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEvent(EventDto eventDto)
        {
            return Ok(await _eventService.UpdateEventAsync(eventDto));
        }

    }
}
