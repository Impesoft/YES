using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;
using static System.Net.WebRequestMethods;


namespace YES.Client.Services
{
    public class EventService : IEventService
    {
        private HttpClient _http;
        public EventService(HttpClient http)
        {
            _http = http;
        }


        public async Task<IEnumerable<EventDto>> GetEventsAsync()
        {
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("https://localhost:44316/api/Event");

            return _events;
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            var _event = await _http.GetFromJsonAsync<EventDto>("https://localhost:44316/api/Event/" + id);

            return _event;
        }



        public async Task<IEnumerable<EventDto>> GetEventSpotlightsAsync()
        {
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("https://localhost:44316/api/Event");
            return _events.Take(3);
        }

    }
}