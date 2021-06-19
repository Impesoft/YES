using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public interface IAccountService
    {
        string LoggedInUserJson { get; set; }
        Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id);
        UserTokenDto GetLoggedInUser();
        Task LogIn(LoginDto logindto);
    }
}