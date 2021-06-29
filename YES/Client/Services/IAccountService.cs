using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Client.Services
{
    public interface IAccountService
    {
        Task<HttpResponseMessage> LogIn(LoginDto logindto);
        void LogOut();
        Task<HttpResponseMessage> RegisterCustomer(RegisterCustomerDto registerCustomerDto);
        Task<HttpResponseMessage> RegisterProvider(RegisterProviderDto registerProviderDto);
    }
}