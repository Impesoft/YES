using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Mobile.Services
{
    public interface IAccountService
    {
        string LoggedInUserJson { get; set; }

        Task LogIn(LoginDto logindto);
    }
}