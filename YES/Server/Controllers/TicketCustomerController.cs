using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Business.Services;
using YES.Shared.Dto;

namespace YES.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketCustomerController : ControllerBase
    {
        private readonly ITicketCustomerService _ticketCustomerService;

        public TicketCustomerController(ITicketCustomerService ticketCustomerService)
        {
            _ticketCustomerService = ticketCustomerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerWithTicketsDto>> GetAllEvents(int id)
        {
            return Ok(await _ticketCustomerService.GetTicketCustomerByIdAsync(id));
        }
    }
}
