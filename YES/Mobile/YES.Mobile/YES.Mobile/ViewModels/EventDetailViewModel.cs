using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Services;

namespace YES.Mobile.ViewModels
{
    [QueryProperty(nameof(EventId), "id")]
    public class EventDetailViewModel : BaseViewModel
    {
      public ICommand LoadEventCommand { get; }

        //LoadEventCommand
        private int _eventId;
        private static IEventService _eventService { get; set; }
        private EventDto _event;
        public EventDto Event {
            get => _event;
            
            set
            {
                _event = value;
                OnPropertyChanged(nameof(Event));

            }
        }
        public int EventId
        {
            get => _eventId;
            set
            {
                _eventId = value;
                OnPropertyChanged(nameof(EventId));
                LoadEvent();
            }
        }

        public EventDetailViewModel()
        {
            Title = "Event Details";
            LoadEventCommand = new Command(LoadEvent);
            //LoadEvent();
        }

        public async void LoadEvent()
        {
            _eventService = new EventService();
            Event = await _eventService.GetEventDetails(EventId);
            // breakpoint hit
        }
    }
}