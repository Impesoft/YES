using YES.Api.Data.Entities;

namespace YES.Api.Business.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}