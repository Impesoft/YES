using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        UserTokenDto GetLoggedInUser();
        string GetLoggedInUserJson();
        Task<string> LogIn(LoginDto logindto);
        Task RegisterUser(RegisterDto registerDto);
        void LogOut();
    }
}