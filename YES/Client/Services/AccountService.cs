using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace YES.Client.Services
{
    public class AccountService : IAccountService
    {
        private UserTokenDto LoggedInUser { get; set; }

        private HttpClient _http;
        public AccountService(HttpClient http)
        {
            _http = http;
        }

        public async Task LogIn(LoginDto logindto)
        {
            var _loggedInUser = await _http.PostAsJsonAsync("/api/Account/Login", logindto);
            
            //var responseStream = await _loggedInUser.Content.ReadAsStreamAsync();
            var responseString = await _loggedInUser.Content.ReadAsStringAsync();

            if (_loggedInUser != null)
            {
                //LoggedInUser = await JsonSerializer.DeserializeAsync<UserTokenDto>(responseStream);
                LoggedInUser = JsonConvert.DeserializeObject<UserTokenDto>(responseString);
            }
           
        }

        public async Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id)
        {
            var _customer = await _http.GetFromJsonAsync<CustomerWithTicketsDto>("api/TicketCustomer/IncludeTickets/" + id);

            return _customer;
        }


        public UserTokenDto GetLoggedInUser()
        {
            return LoggedInUser;
        }
    }
}
