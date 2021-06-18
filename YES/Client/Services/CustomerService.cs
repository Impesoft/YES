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
        private int LoggedInUserId { get; set; } = 1;

        private HttpClient _http;
        public CustomerService(HttpClient http)
        {
            _http = http;
            //_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJ3YXJkaW1wZSIsIm5iZiI6MTYyMzk2MDg1OCwiZXhwIjoxNjI0NTY1NjU4LCJpYXQiOjE2MjM5NjA4NTh9.qeNxS_ex5NE4lFE6w18v7S2K3G1ScOd--tkLs4UdGQIT9WFcjNyikEXMwMQ24KmPbRDD2M9OxbYl_b_Nk82NJw");
        }

        public async Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id)
        {
            var _customer = await _http.GetFromJsonAsync<CustomerWithTicketsDto>("api/TicketCustomer/IncludeTickets/" + id);

            LoggedInUserId = _customer.Id;
            return _customer;
        }

        public async Task UpdateCustomer(CustomerWithTicketsDto customer)
        {
            await _http.PutAsJsonAsync("api/TicketCustomer", customer);
        }

        public int GetLoggedInUser()
        {
            return LoggedInUserId;
        }

    }
}
