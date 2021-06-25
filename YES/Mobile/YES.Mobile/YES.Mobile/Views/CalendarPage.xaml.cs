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
using System.Collections.ObjectModel;

namespace YES.Mobile.Views
{
    public partial class CalendarPage : ContentPage
    {
        private CalendarViewModel ThisVM { get; set; }
        public ICollection<EventDto> FilteredEvents;

        public CalendarPage()
        {
            InitializeComponent();
            ThisVM = new CalendarViewModel();
            BindingContext = ThisVM;
        }

        private void LoadEvents(object sender, EventArgs e)
        {
            //   LoadEvents();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }
            searchTerm = searchTerm.ToLowerInvariant();
            //   FilteredEvents = ThisVM.Events.Where<EventDto>(event = > event.  .ToLowerInvariant().Contains(searchTerm)).ToList();
        }
    }
}