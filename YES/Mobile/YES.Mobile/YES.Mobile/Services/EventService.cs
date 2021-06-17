using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public class EventService : IEventService
    {
        public async Task<ObservableCollection<EventDto>> GetAllEvents()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            HttpClient httpClient = new HttpClient(insecureHandler);

            var resultJson = httpClient.GetStringAsync("https://yesapi.azurewebsites.net/api/Event").Result;

            var resultEvents = JsonConvert.DeserializeObject<ObservableCollection<EventDto>>(resultJson);
            return resultEvents;
        }
    }
}
