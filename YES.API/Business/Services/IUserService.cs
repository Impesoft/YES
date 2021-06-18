using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;

namespace YES.Api.Business.Services
{
    public interface IUserService
    {        
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> UserExistsAsync(string eMail);
        Task<User> GetUserByEmailAsync(string email);
    }
}