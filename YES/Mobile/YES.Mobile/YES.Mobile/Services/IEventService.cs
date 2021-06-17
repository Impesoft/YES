using System.Collections.ObjectModel;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public interface IEventService
    {
        ObservableCollection<EventDto> GetAllEvents();
        EventDto GetEventDetails(int id);
    }
}