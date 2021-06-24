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
        private IAccountService _accountService;
        public TicketService(HttpClient http, IAccountService accountService)
        {            
            _accountService = accountService;
            _http = http;

            if (GlobalVariables.LoggedInUser != null)
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVariables.LoggedInUser.Token);
            }
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

        public async Task<bool> CancelTicketsAsync(List<int> ticketsToCancel)
        {
            var result = await _http.PostAsJsonAsync("api/Ticket/Cancel", ticketsToCancel);

            return result.IsSuccessStatusCode;
        }

    }
}
