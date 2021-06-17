using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using YES.Mobile.Dto;
using YES.Mobile.Services;

namespace YES.Mobile.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        private static ICollection<EventDto> _events;
        private static IEventService _eventService { get; set; }
        public ICollection<EventDto> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        public EventsViewModel()
        {
            _eventService = new EventService();
            Events = new ObservableCollection<EventDto>();
            LoadEvents(_eventService);

        }
        public void LoadEvents(IEventService eventService)
        {
            Events = eventService.GetAllEvents();

        }

    }
}
