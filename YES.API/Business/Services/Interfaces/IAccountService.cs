using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public interface IAccountService
    {
        Task<UserTokenDto> LoginAsync(string eMail, string password);
        Task<UserTokenDto> RegisterAsync(RegisterDto dto);
    }
}