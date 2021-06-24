using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public interface ICustomerService
    {
        string LoggedInUserJson { get; set; }

        Task<CustomerWithTicketsDto> GetCustomerAsync();
    }
}