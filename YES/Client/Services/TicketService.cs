using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJ3YXJkaW1wZSIsIm5iZiI6MTYyMzk2MDg1OCwiZXhwIjoxNjI0NTY1NjU4LCJpYXQiOjE2MjM5NjA4NTh9.qeNxS_ex5NE4lFE6w18v7S2K3G1ScOd--tkLs4UdGQIT9WFcjNyikEXMwMQ24KmPbRDD2M9OxbYl_b_Nk82NJw");
        }


        public async Task<IEnumerable<TicketDto>> GetTicketsByUserIdAsync(int id)
        {
            var _tickets = await _http.GetFromJsonAsync<IEnumerable<TicketDto>>("api/Ticket/" + id);

            return _tickets;
        }

        public async Task AddNewTicketsAsync(List<TicketPurchaseDto> tickets)
        {
            await _http.PostAsJsonAsync<List<TicketPurchaseDto>>("api/Ticket/Buy", tickets);
          
        }

    }
}
