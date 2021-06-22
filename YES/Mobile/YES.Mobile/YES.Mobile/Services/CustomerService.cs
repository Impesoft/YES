using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public class CustomerService : ICustomerService
    {
        private UserTokenDto LoggedInUser { get; set; }

        public string LoggedInUserJson { get; set; }

        private HttpClient _http;

        public CustomerService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            _http = new HttpClient(insecureHandler);
        }

        public async Task<CustomerWithTicketsDto> GetCustomerByIdAsync(UserTokenDto loggedInUser)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loggedInUser.Token);
            var loggedInUserWithTicketJson = await _http.GetStringAsync("https://yesapi.azurewebsites.net/api/TicketCustomer/IncludeTickets/" + loggedInUser.Id);
            var loggedInUserWithTicket = JsonConvert.DeserializeObject<CustomerWithTicketsDto>(loggedInUserWithTicketJson);
            return loggedInUserWithTicket;
        }

        public UserTokenDto GetLoggedInUser()
        {
            return LoggedInUser;
        }
    }
}