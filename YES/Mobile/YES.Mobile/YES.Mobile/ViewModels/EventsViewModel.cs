using System;
using System.Collections.Generic;
using System.Text;
using YES.Mobile.Dto;
using YES.Mobile.Services;

namespace YES.Mobile.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        private static IEventService _eventService { get; set; }

        public EventsViewModel(IEventService eventService)
        {
            _eventService = eventService;

        }
        public static async void LoadEvents(System.Object sender, System.EventArgs e)
        {
            EventDto[] resultEvents = await _eventService.GetAllEvents();

        }

    }
}
