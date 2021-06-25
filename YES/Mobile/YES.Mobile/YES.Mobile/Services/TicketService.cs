using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using YES.Mobile.Dto;
using YES.Mobile.Enums;

namespace YES.Mobile.Services
{
    public class TicketService : ITicketService
    {
        private HttpClient _http;
        private UserTokenDto _loggedInUser;

        public TicketService()
        {
            if (GlobalVariables.LoggedInUser != null)
            {
                _loggedInUser = GlobalVariables.LoggedInUser;
            }

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            _http = new HttpClient(insecureHandler);

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _loggedInUser.Token);
        }

        public async Task<HttpResponseMessage> BuyTicketsAsync(IEnumerable<TicketPurchaseDto> tickets)
        {
            string ticketsJson = JsonConvert.SerializeObject(tickets);
            StringContent myStringContent = new StringContent(ticketsJson.ToString(), Encoding.UTF8, "application/json");

            var _tickets = await _http.PostAsync("https://yesapi.azurewebsites.net/api/Ticket/Buy/", myStringContent);
            return _tickets;
        }

        public async Task<bool> CancelTicketsAsync(List<int> ticketsToCancel)
        {
            var result = await _http.PostAsJsonAsync("api/Ticket/Cancel", ticketsToCancel);

            return result.IsSuccessStatusCode;
        }
    }
}