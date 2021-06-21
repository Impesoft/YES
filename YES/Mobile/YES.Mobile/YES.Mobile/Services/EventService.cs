using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public class EventService : IEventService
    {
        private HttpClient httpClient;
        public EventService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            httpClient = new HttpClient(insecureHandler);

        }
        public async Task<ObservableCollection<EventDto>> GetAllEvents()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJib2JAaG90bWFsZS5jb20iLCJuYmYiOjE2MjM5NjU5ODIsImV4cCI6MTYyNDU3MDc4MiwiaWF0IjoxNjIzOTY1OTgyfQ.ylvckb4lGHQBMeK2i1TR9auSZkYWhB7nYg9ZbkA0QrexHVeT9ES1WaXJDkpN3C4YemcquCbV6o-IAMvI1cAMUA");

            var resultJson = await httpClient.GetStringAsync("https://yesapi.azurewebsites.net/api/Event");

            var resultEvents = JsonConvert.DeserializeObject<ObservableCollection<EventDto>>(resultJson);
            return resultEvents;
        }
        public async Task<EventDto> GetEventDetails(int id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJib2JAaG90bWFsZS5jb20iLCJuYmYiOjE2MjM5NjU5ODIsImV4cCI6MTYyNDU3MDc4MiwiaWF0IjoxNjIzOTY1OTgyfQ.ylvckb4lGHQBMeK2i1TR9auSZkYWhB7nYg9ZbkA0QrexHVeT9ES1WaXJDkpN3C4YemcquCbV6o-IAMvI1cAMUA");

            var resultJson = await httpClient.GetStringAsync("https://yesapi.azurewebsites.net/api/Event/" + id);

            var eventsDetails = JsonConvert.DeserializeObject<EventDto>(resultJson);
            return eventsDetails;
        }


    }
}
