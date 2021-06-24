using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        Task<string> LogIn(LoginDto logindto);
        Task<bool> RegisterUser(RegisterDto registerDto);
        void LogOut();
    }
}