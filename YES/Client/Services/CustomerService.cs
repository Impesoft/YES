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
    public class CustomerService : ICustomerService
    {
        private HttpClient _http;

        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id)
        {
            var _customer = await _http.GetFromJsonAsync<CustomerWithTicketsDto>("api/TicketCustomer/IncludeTickets/" + id);

            return _customer;
        }

        public async Task<HttpResponseMessage> UpdateCustomer(CustomerWithTicketsDto customerWithTickets)
        {
            TicketCustomerDto customer = ConvertToTicketCustomer(customerWithTickets);
            var response = await _http.PutAsJsonAsync("api/TicketCustomer", customer);

            return response;
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