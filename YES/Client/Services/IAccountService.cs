using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        Task<string> LogIn(LoginDto logindto);
        Task<HttpResponseMessage> RegisterUser(RegisterDto registerDto);
        void LogOut();
    }
}