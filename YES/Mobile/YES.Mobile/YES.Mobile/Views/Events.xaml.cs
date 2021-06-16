using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using YES.Mobile.Models;
using Newtonsoft.Json;
using YES.Mobile.Dto;

namespace YES.Mobile.Views
{
    public partial class Events : ContentPage
    {
        public Events()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            HttpClient httpClient = new HttpClient(insecureHandler);

            var resultJson = await httpClient.GetStringAsync("https://yesapi.azurewebsites.net/api/Event");

            var resultEvents = JsonConvert.DeserializeObject<EventDto[]>(resultJson);

            ListOfEvents.ItemsSource = resultEvents;
        }
    }
}