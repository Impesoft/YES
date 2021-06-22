using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public interface ITicketCustomerService
    {
        Task<TicketCustomerDto> GetTicketCustomerByIdAsync(int id);
        Task<CustomerWithTicketsDto> GetTicketCustomerWithTicketsByIdAsync(int id);        
        Task<bool> UpdateTicketCustomer(TicketCustomerDto ticketCustomerDto);
        Task<bool> DeleteTicketCustomer(int id);       
    }
}