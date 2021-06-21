using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id);
        UserTokenDto GetLoggedInUser();
        string GetLoggedInUserJson();
        Task<string> LogIn(LoginDto logindto);
        void LogOut();
    }
}