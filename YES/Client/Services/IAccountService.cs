using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        Task<HttpResponseMessage> LogIn(LoginDto logindto);
        Task<HttpResponseMessage> RegisterUser(RegisterCustomerDto registerCustomerDto, RegisterProviderDto registerProviderDto);
        void LogOut();
    }
}