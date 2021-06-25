﻿using System;
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
        private ICollection<EventDto> _events;
        private ICollection<EventDto> _eventsFiltered;
        private IEventService _eventService { get; set; }

        //public Command<EventDto> EventTappedCommand => new Command<EventDto>(OnEventSelected);
        public Command<string> FilterListCommand { get; }

        public Command<EventDto> EventTappedCommand { get; }

        public ICommand EventLoadCommand { get; set; }
        public bool DBIsBusy { get; set; }
        public string SearchTerm { get; set; }

        public ICollection<EventDto> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));

                EventsFiltered = Events.Where(x => x.EventInfo.Description.ToLowerInvariant().Contains(SearchTerm)).ToList();
            }
        }

        public ICollection<EventDto> EventsFiltered
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

        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                {
                    EventsFiltered = Events.Where(x => x.EventInfo.Description.ToLowerInvariant().Contains(SearchText.ToLowerInvariant())).ToList();
                }));
            }
        }

        public CalendarViewModel()
        {
            Title = "Calendar";

            _eventService = new EventService();
            Events = new ObservableCollection<EventDto>();
            EventsFiltered = new ObservableCollection<EventDto>();

            EventLoadCommand = new Command((async () => await LoadEvents()));
            EventTappedCommand = new Command<EventDto>(OnEventSelected);
            Task.Run(() => LoadEvents());
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