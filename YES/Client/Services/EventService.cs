using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared;
using static System.Net.WebRequestMethods;


namespace YES.Client.Services
{
    public class EventService : IEventService
    {
        private IEnumerable<EventDTO> _events;
        private HttpClient _http;

        public EventService(HttpClient http)
        {
            _http = http;

            SetEventsTest();
        }
        public async Task GetEventsFromAPIAsync()
        {
            try
            {
                _events = await _http.GetFromJsonAsync<ICollection<EventDTO>>("Event");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            return _events;
        }

        public IEnumerable<EventDTO> GetEventSpotlights()
        {
            return _events.Take(3);
        }

        //TEST WITH DUMMY DATA
        public void SetEventsTest()
        {
            _events = new List<EventDTO>
            {
                new (){Name = "Tomorrowland"},
                new (){Name = "Werchter"},
                new (){Name = "Pukkelpop"},
                new (){Name = "10 om te zien aan de kust"},
            };
        }
    }
}