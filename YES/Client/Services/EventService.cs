using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;
using YES.Shared.GlobalClasses;
using static System.Net.WebRequestMethods;

namespace YES.Client.Services
{
    public class EventService : IEventService
    {
        private HttpClient _http;

        public EventService(HttpClient http)
        {
            _http = http;

            if (GlobalVariables.LoggedInUser != null)
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVariables.LoggedInUser.Token);
            }
            
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
            return _events.Where(x => x.EventInfo.EventDate > DateTime.Now).OrderBy(x => Guid.NewGuid()).Take(6).OrderBy(x => x.EventInfo.EventDate);
        }

        public async Task<bool> CreateNewEventAsync(EventDto eventDto)
        {
            var responseMessage = await _http.PostAsJsonAsync("api/Event/", eventDto);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEventAsync(EventDto eventDto)
        {
            var responseMessage = await _http.PutAsJsonAsync("api/Event/", eventDto);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<VenueDto>> GetVenuesAsync()
        {
            var venues = await _http.GetFromJsonAsync<IEnumerable<VenueDto>>("api/Event/Venues");

            return venues;
        }

        public async Task<IEnumerable<EventDto>> GetEventsByProviderIdAsync(int id)
        {
            var _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("api/Event/Provider/" + id);

            return _events.OrderBy(x => x.EventInfo.EventDate);
        }
    }
}