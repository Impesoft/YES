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
    public class ProviderService : IProviderService
    {
        private HttpClient _http;

        public ProviderService(HttpClient http)
        {
            _http = http;

            if (GlobalVariables.LoggedInUser != null)
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVariables.LoggedInUser.Token);
            }
        }

        public async Task<TicketProviderDto> GetProviderByIdAsync(int id)
        {
            var provider = await _http.GetFromJsonAsync<TicketProviderDto>("api/TicketProvider/" + id);

            return provider;
        }

        public async Task<HttpResponseMessage> UpdateProvider(TicketProviderDto provider)
        {
            var response = await _http.PutAsJsonAsync("api/TicketProvider", provider);
            return response;
        }
    }
}
