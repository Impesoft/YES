using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        public string LoggedInUserJson { get; set; }
        Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id);
        UserTokenDto GetLoggedInUser();
        Task LogIn(LoginDto logindto);
    }
}