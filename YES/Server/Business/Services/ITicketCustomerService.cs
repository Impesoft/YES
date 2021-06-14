using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Server.Business.Services
{
    public interface ITicketCustomerService
    {
        Task<CustomerWithTicketsDto> GetTicketCustomerByIdAsync(int id);
    }
}