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
        private IEnumerable<EventDto> _events;
        private HttpClient _http;

        public EventService(HttpClient http)
        {
            _http = http;

        }
        public async Task<IEnumerable<EventDto>> GetEventsFromAPIAsync()
        {
            _events = await _http.GetFromJsonAsync<ICollection<EventDto>>("https://localhost:44316/api/Event");

            return _events;
        }

        public IEnumerable<EventDto> GetEvents()
        {
            return _events;
        }

        public IEnumerable<EventDto> GetEventSpotlights()
        {
            return _events.Take(3);
        }

        //TEST WITH DUMMY DATA
        public void SetEventsTest()
        {
            //_events = new List<EventDto>
            //{
            //    new (){Name = "Tomorrowland"},
            //    new (){Name = "Werchter"},
            //    new (){Name = "Pukkelpop"},
            //    new (){Name = "10 om te zien aan de kust"},
            //};
        }
    }
}