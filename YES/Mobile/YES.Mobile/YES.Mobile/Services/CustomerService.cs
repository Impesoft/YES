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

        //private HttpResponseMessage message;
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
            //   var _customer = await _http.GetFromJsonAsync<CustomerWithTicketsDto>("api/TicketCustomer/IncludeTickets/" + id);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loggedInUser.Token);
            var content = await _http.GetStringAsync("https://yesapi.azurewebsites.net/api/TicketCustomer/IncludeTickets/" + loggedInUser.Id);
            var test = JsonConvert.DeserializeObject<CustomerWithTicketsDto>(content);
            return test;
            //return JsonConvert.DeserializeObject<CustomerWithTicketsDto>(content);
        }

        public UserTokenDto GetLoggedInUser()
        {
            return LoggedInUser;
        }

        private TicketCustomerDto ConvertToTicketCustomer(CustomerWithTicketsDto customer)
        {
            return new TicketCustomerDto()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                BankAccount = customer.BankAccount,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };
        }
    }
}