using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public class TicketService : ITicketService
    {
        private HttpClient _http;
        public TicketService(HttpClient http)
        {
            _http = http;
        }


        public async Task<IEnumerable<TicketDto>> GetTicketsByUserIdAsync(int id)
        {
            var _tickets = await _http.GetFromJsonAsync<IEnumerable<TicketDto>>("https://localhost:44316/api/Ticket/" + id);

            return _tickets;
        }

        public async Task AddNewTicketsAsync(List<TicketPurchaseDto> tickets)
        {
            await _http.PostAsJsonAsync<List<TicketPurchaseDto>>("https://localhost:44316/api/Ticket/", tickets);
        }

    }
}
