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
using YES.Mobile.Views;

namespace YES.Mobile.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private ICollection<EventDto> _events;
        private IEventService _eventService { get; set; }

        //public Command<EventDto> EventTappedCommand => new Command<EventDto>(OnEventSelected);
        public Command<EventDto> EventTappedCommand { get; }

        public ICommand EventLoadCommand { get; set; }

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
            LoadEvents();

            EventLoadCommand = new Command(LoadEvents);
            EventTappedCommand = new Command<EventDto>(OnEventSelected);
        }

        private async void OnEventSelected(EventDto test)
        {
            await Shell.Current.GoToAsync($"{nameof(EventDetailPage)}?{nameof(EventDetailViewModel.Event.Id)}={test.Id}");
        }

        public void LoadEvents()
        {
            Events = _eventService.GetAllEvents();
        }

        //private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        //{
        //    if (!Equals(field, newValue))
        //    {
        //        field = newValue;
        //        PropertyChanged ?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //        PropertyChanged += new PropertyChangedEventArgs(propertyName);
        //        return true;
        //    }

        //    return false;
        //}
    }
}