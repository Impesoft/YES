using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJ3YXJkaW1wZSIsIm5iZiI6MTYyMzk2MDg1OCwiZXhwIjoxNjI0NTY1NjU4LCJpYXQiOjE2MjM5NjA4NTh9.qeNxS_ex5NE4lFE6w18v7S2K3G1ScOd--tkLs4UdGQIT9WFcjNyikEXMwMQ24KmPbRDD2M9OxbYl_b_Nk82NJw");
        }

        //https://localhost:44316/api/Event

        public async Task<IEnumerable<EventDto>> GetEventsAsync()
        {
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("api/Event");

            return _events.OrderBy(x => x.EventInfo.EventDate);
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            var _event = await _http.GetFromJsonAsync<EventDto>("api/Event/" + id);

            return _event;
        }



        public async Task<IEnumerable<EventDto>> GetEventSpotlightsAsync()
        {
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("/api/Event");
            return _events.Take(6);
        }

    }
}