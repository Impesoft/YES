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
using YES.Mobile.ViewModels;

namespace YES.Mobile.Views
{
    public partial class Events : ContentPage
    {
        EventsViewModel eventsViewModel;
        public Events()
        {
            InitializeComponent();
            BindingContext = eventsViewModel = new EventsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            eventsViewModel.LoadEvents();
            ListOfEvents.ItemsSource = resultEvents;

        }


    }
}