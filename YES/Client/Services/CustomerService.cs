using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

    }
}
