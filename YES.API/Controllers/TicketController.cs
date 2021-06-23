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
        public async Task<ActionResult<bool>> BuyTickets(ICollection<TicketPurchaseDto> ticketPurchaseDtos, bool sendInvoice)
        {
            return Ok(await _ticketService.BuyTickets(ticketPurchaseDtos, sendInvoice));
        }

        [HttpPost("Cancel")]
        public async Task<ActionResult<bool>> CancelTickets(ICollection<int> canceledTicketIds)
        {
            return Ok(await _ticketService.CancelTickets(canceledTicketIds));
        }     
    }
}
