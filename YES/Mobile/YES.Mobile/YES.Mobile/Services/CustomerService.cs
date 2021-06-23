using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YES.Mobile.Dto;
using YES.Mobile.Enums;

namespace YES.Mobile.Services
{
    public class CustomerService : ICustomerService
    {
        private UserTokenDto LoggedInUser { get; set; }

        public string LoggedInUserJson { get; set; }

        private HttpClient _http;

        public CustomerService()
        {
            HttpClientHandler handler = new();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            _http = new HttpClient(insecureHandler);
            LoggedInUser = GlobalVariables.LoggedInUser;
        }

        public async Task<CustomerWithTicketsDto> GetCustomerAsync()
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoggedInUser.Token);
            string loggedInUserWithTicketJson = await _http.GetStringAsync("https://yesapi.azurewebsites.net/api/TicketCustomer/IncludeTickets/" + LoggedInUser.Id);
            CustomerWithTicketsDto loggedInUserWithTicket = JsonConvert.DeserializeObject<CustomerWithTicketsDto>(loggedInUserWithTicketJson);
            return loggedInUserWithTicket;
        }
    }
}