using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "TicketCustomer")]
        [HttpGet("IncludeTickets/{id}")]
        public async Task<ActionResult<CustomerWithTicketsDto>> GetTicketCustomerWithTickets(int id)
        {
            return Ok(await _ticketCustomerService.GetTicketCustomerWithTicketsByIdAsync(id));
        }

        [Authorize(Roles = "TicketCustomer")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketCustomerDto>> GetTicketCustomer(int id)
        {
            return Ok(await _ticketCustomerService.GetTicketCustomerByIdAsync(id));
        }

        [Authorize(Roles = "TicketCustomer")]
        [HttpPut]
        public async Task<ActionResult> UpdateTicketCustomer(TicketCustomerDto ticketCustomerDto)
        {
            if (await _ticketCustomerService.UpdateTicketCustomer(ticketCustomerDto))
            {
                return Ok("Succesfully updated ticketCustomer");
            }
            return StatusCode(500, "Failed to update ticketCustomer");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTicketCustomer(int id)
        {
            if (await _ticketCustomerService.DeleteTicketCustomer(id))
            {
                return Ok("Succesfully deleted ticketCustomer");
            }
            return StatusCode(500, "Failed to delete ticketCustomer");
        }
    }
}
