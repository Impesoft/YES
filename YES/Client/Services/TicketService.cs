using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;
using YES.Shared.GlobalClasses;

namespace YES.Client.Services
{
    public class TicketService : ITicketService
    {
        private HttpClient _http;
        public TicketService(HttpClient http)
        {            
            _http = http;

            if (GlobalVariables.LoggedInUser != null)
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVariables.LoggedInUser.Token);
            }
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByUserIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<IEnumerable<TicketDto>>("api/Ticket/" + id);            
        }

        public async Task<HttpResponseMessage> AddNewTicketsAsync(List<TicketPurchaseDto> tickets)
        {
            return await _http.PostAsJsonAsync("api/Ticket/Buy", tickets);
        }

        public async Task<HttpResponseMessage> CancelTicketsAsync(List<int> ticketsToCancel)
        {
            return await _http.PostAsJsonAsync("api/Ticket/Cancel", ticketsToCancel);
        }

    }
}
