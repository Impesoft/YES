using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id);
        UserTokenDto GetLoggedInUser();
        Task LogIn(LoginDto logindto);
    }
}