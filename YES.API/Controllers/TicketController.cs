using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Business.Services;
using YES.Shared.Dto;

namespace YES.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("Buy")]
        public async Task<ActionResult<bool>> BuyTickets(ICollection<TicketPurchaseDto> ticketPurchaseDtos)
        {
            if (await _ticketService.BuyTickets(ticketPurchaseDtos))
            {
                return Ok($"Successfully bought {ticketPurchaseDtos.Count} tickets");
            }
            return StatusCode(500, "Failed to buy tickets");
        }

        [HttpPost("Cancel")]
        public async Task<ActionResult<bool>> CancelTickets(ICollection<int> canceledTicketIds)
        {
            if (await _ticketService.CancelTickets(canceledTicketIds))
            {
                return Ok($"Successfully canceled {canceledTicketIds.Count} tickets");
            }
            return StatusCode(500, "Failed to cancel tickets");
        }     
    }
}
