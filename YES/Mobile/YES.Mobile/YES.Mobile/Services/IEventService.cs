using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
   public interface IEventService
    {
        Task<EventDto[]> GetAllEvents();
    }
}