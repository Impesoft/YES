using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YES.Api.Business.Services;
using YES.Shared.Dto;

namespace YES.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserTokenDto>> RegisterAsync(RegisterDto dto)
        {
            return Created("/api/user/{dto.Id}", await _service.RegisterAsync(dto));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserTokenDto>> LoginAsync(LoginDto dto)
        {
            try
            {
                return Ok(await _service.LoginAsync(dto.Email, dto.Password));
            }
            catch (System.UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
