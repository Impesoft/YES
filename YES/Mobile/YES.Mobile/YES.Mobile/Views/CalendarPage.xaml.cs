using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using YES.Mobile.Dto;
using YES.Mobile.Services;
using YES.Mobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace YES.Mobile.Views
{
    public partial class CalendarPage : ContentPage
    {
        private CalendarViewModel eventsViewModel;

        public CalendarPage()
        {
            InitializeComponent();
            BindingContext = new CalendarViewModel();
        }

        protected override void OnAppearing()
        {
            // base.OnAppearing();
            //ListOfEvents.ItemsSource = eventsViewModel.Events;
        }
    }
}