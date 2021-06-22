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

        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost]
        public async Task<ActionResult> AddTicketCustomer(TicketProviderDto ticketProviderDto)
        {
            return Ok(await _ticketProviderService.AddTicketProvider(ticketProviderDto));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTicketCustomer(TicketProviderDto ticketProviderDto)
        {
            return Ok(await _ticketProviderService.UpdateTicketProvider(ticketProviderDto));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTicketProvider(int id)
        {
            return Ok(await _ticketProviderService.DeleteTicketProvider(id));
        }
    }
}
