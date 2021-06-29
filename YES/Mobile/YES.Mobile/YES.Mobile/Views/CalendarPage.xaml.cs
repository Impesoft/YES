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
        public CalendarViewModel MyVM { get; set; }
        public ICollection<EventDto> LocalEvents;

        public CalendarPage()
        {
            InitializeComponent();
            MyVM = new CalendarViewModel();
            BindingContext = MyVM;
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            IsBusy = true;
            await MyVM.LoadEvents();
            IsBusy = false;
        }
    }
}