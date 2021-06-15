using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Server.Business.Services
{
    public interface ITicketCustomerService
    {
        Task<TicketCustomerDto> GetTicketCustomerByIdAsync(int id);
        Task<CustomerWithTicketsDto> GetTicketCustomerWithTicketsByIdAsync(int id);
        Task<bool> AddTicketCustomer(TicketCustomerDto ticketCustomerDto);
        Task<bool> UpdateTicketCustomer(TicketCustomerDto ticketCustomerDto);
        Task<bool> DeleteTicketCustomer(int id);       
    }
}