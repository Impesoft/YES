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
using YES.Mobile.Services;

namespace YES.Mobile.Views
{
    public partial class Events : ContentPage
    {
        private IEventService _eventService { get; set; }
        public Events(IEventService eventService)
        {
            InitializeComponent();
            _eventService = eventService;
        }

        private async void LoadEvents(System.Object sender, System.EventArgs e)
        {
            EventDto[] resultEvents = await _eventService.GetAllEvents();

            ListOfEvents.ItemsSource = resultEvents;
        }

  
    }
}