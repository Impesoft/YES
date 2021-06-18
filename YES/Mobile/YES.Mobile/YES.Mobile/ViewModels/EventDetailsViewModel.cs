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
    class EventDetailsViewModel : BaseViewModel
    {
        private static EventDto _event;
        private static IEventService _eventService { get; set; }

        public EventDto Event
    {
        get => _event;
        set
        {
            _event = value;
                OnPropertyChanged(nameof(Event));
            }
        }
    //public EventDetailsViewModel()
    //{
    //        _eventService = new EventService();
    //        Event = new EventDto();
    //        LoadEvent(_eventService, id);
    //}

        private void LoadEvent(IEventService eventService, int id)
        {
            Event = eventService.GetEventDetails(id);
                }
    }
}
