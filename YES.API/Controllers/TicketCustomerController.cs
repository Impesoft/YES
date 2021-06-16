using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YES.Api.Business.Services;
using YES.Shared.Dto;

namespace YES.Api.Controllers
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

        [HttpGet("IncludeTickets/{id}")]
        public async Task<ActionResult<CustomerWithTicketsDto>> GetTicketCustomerWithTickets(int id)
        {
            return Ok(await _ticketCustomerService.GetTicketCustomerWithTicketsByIdAsync(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketCustomerDto>> GetTicketCustomer(int id)
        {
            return Ok(await _ticketCustomerService.GetTicketCustomerByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddTicketCustomer(TicketCustomerDto ticketCustomerDto)
        {
            return Ok(await _ticketCustomerService.AddTicketCustomer(ticketCustomerDto));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTicketCustomer(TicketCustomerDto ticketCustomerDto)
        {
            return Ok(await _ticketCustomerService.UpdateTicketCustomer(ticketCustomerDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTicketCustomer(int id)
        {
            return Ok(await _ticketCustomerService.DeleteTicketCustomer(id));
        }
    }
}
