using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Services;
using YES.Mobile.Views;

namespace YES.Mobile.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private ICollection<EventDto> _events;
        private IEventService _eventService { get; set; }

        //public Command<EventDto> EventTappedCommand => new Command<EventDto>(OnEventSelected);
        public Command<string> FilterListCommand { get; }
        public Command<EventDto> EventTappedCommand { get; }

        public ICommand EventLoadCommand { get; set; }
        public bool DBIsBusy { get; set; }

        public ICollection<EventDto> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        public CalendarViewModel()
        {
            Title = "Calendar";

            _eventService = new EventService();
            Events = new ObservableCollection<EventDto>();
            Task.Run(() => LoadEvents());

            EventLoadCommand = new Command((async () => await LoadEvents()));
            EventTappedCommand = new Command<EventDto>(OnEventSelected);
        }

        private async void OnEventSelected(EventDto eventDto)
        {
            await Shell.Current.GoToAsync($"{nameof(EventDetailPage)}?id={eventDto.Id}");
        }

        public async Task LoadEvents()
        {
            IsBusy = true;
            Events = await _eventService.GetAllEvents();
            IsBusy = false;
            Debug.Write("Debug:" + Events);
        }
    }
}