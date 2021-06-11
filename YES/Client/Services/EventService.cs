using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared;
using static System.Net.WebRequestMethods;


namespace YES.Client.Services
{
    public class EventService
    {
        private ICollection<EventDTO> _events;
        private HttpClient _http;

        public EventService(HttpClient http)
        {
            _http = http;
        }
        public async Task GetEventsAsync()
        {
            try
            {
               //_events = await _http.GetAsync GetFromJsonAsync<ICollection<EventDTO>>("Event");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}