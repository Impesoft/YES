using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface ICustomerService
    {
        Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id);
        Task<HttpResponseMessage> UpdateCustomer(CustomerWithTicketsDto customerWithTickets);
    }
}