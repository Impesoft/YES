using System.Collections.ObjectModel;
using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public interface IEventService
    {
        Task<ObservableCollection<EventDto>> GetAllEvents();
        Task<EventDto> GetEventDetails(int id);
    }
}