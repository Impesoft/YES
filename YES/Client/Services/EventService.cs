using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;


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
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("https://localhost:5003/api/Event");

            return _events.OrderBy(x => x.EventInfo.EventDate);
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            var _event = await _http.GetFromJsonAsync<EventDto>("https://localhost:5003/api/Event/" + id);

            return _event;
        }
        
        public async Task<IEnumerable<EventDto>> GetEventSpotlightsAsync()
        {
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("https://localhost:5003/api/Event");
            return _events.Take(6);
        }
        
        //TODO
        public async Task<IEnumerable<EventDto>> GetFilteredEvents(string userInput)
        {
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("https://localhost:5003/api/Event");
            return _events.Contains(userInput);
        }
    }
}