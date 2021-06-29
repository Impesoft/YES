using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
        private IEnumerable<EventDto> _events;
        private IEnumerable<EventDto> _eventsFiltered;
        private IEventService _eventService { get; set; }
        public Command<string> FilterListCommand { get; }

        public Command<EventDto> EventTappedCommand { get; }

        public ICommand EventLoadCommand { get; set; }
        public bool DBIsBusy { get; set; }
        public string SearchTerm { get; set; }

        public IEnumerable<EventDto> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        public IEnumerable<EventDto> EventsFiltered
        {
            get => _eventsFiltered;
            set
            {
                _eventsFiltered = value;
                OnPropertyChanged(nameof(EventsFiltered));
            }
        }

        private string _searchText { get; set; }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                }
                OnPropertyChanged();
            }
        }

        private ICommand _searchCommand;

        public ICommand SearchCommand => _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                                                       {
                                                           if (SearchText.Length >= 1)
                                                           {
                                                               EventsFiltered = Events.Where<EventDto>(x => x.EventInfo.Description.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())
                                                               || x.EventInfo.Name.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())
                                                               || x.Venue.Name.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())
                                                               || x.TicketProvider.NameProvider.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())
                                                               ).ToList();
                                                           }
                                                           else
                                                           {
                                                               EventsFiltered = Events.Where(x => (x.EventInfo.EventDate == DateTime.MinValue) || (x.Status == "ToBeAnnounced") || (x.EventInfo.EventDate > DateTime.Now));
                                                           }
                                                       }));

        public CalendarViewModel()
        {
            Title = "Calendar";

            _eventService = new EventService();
            Events = new ObservableCollection<EventDto>();
            EventsFiltered = new ObservableCollection<EventDto>();
            EventLoadCommand = new Command(async () => await LoadEvents());
            EventTappedCommand = new Command<EventDto>(OnEventSelected);
            EventsFiltered = Events;
        }

        private async void OnEventSelected(EventDto eventDto)
        {
            await Shell.Current.GoToAsync($"{nameof(EventDetailPage)}?id={eventDto.Id}");
        }

        public async Task LoadEvents()
        {
            IsBusy = true;
            await Task.Run(async () =>
            {
                var EventTasks = await Task.WhenAny(_eventService.GetAllEvents());
                Events = EventTasks.Result;
                Events.OrderBy(x => x.EventInfo.EventDate);
                EventsFiltered = Events.Where(x => (x.EventInfo.EventDate == DateTime.MinValue) || (x.Status == "ToBeAnnounced") || (x.EventInfo.EventDate > DateTime.Now));
            });

            IsBusy = false;
            Debug.Write("Debug:" + Events);
        }
    }
}