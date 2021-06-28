using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YES.Api.Business.Services;
using YES.Shared.Dto;

namespace YES.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketProviderController : ControllerBase
    {
        private readonly ITicketProviderService _ticketProviderService;

        public TicketProviderController(ITicketProviderService ticketProviderService)
        {
            _ticketProviderService = ticketProviderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketProviderDto>> GetTicketProvider(int id)
        {
            return Ok(await _ticketProviderService.GetTicketProviderByIdAsync(id));
        }

        [Authorize(Roles = "TicketProvider")]
        [HttpPut]
        public async Task<ActionResult> UpdateTicketProvider(TicketProviderDto ticketProviderDto)
        {
            if (await _ticketProviderService.UpdateTicketProvider(ticketProviderDto))
            {
                return Ok("Successfully updated ticketProvider");
            }
            return StatusCode(500, "Failed to update ticketProvider");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTicketProvider(int id)
        {
            if (await _ticketProviderService.DeleteTicketProvider(id))
            {
                return Ok("Successfully deleted ticketProvider");
            }
            return StatusCode(500, "Failed to delete ticketProvider");
        }
    }
}
