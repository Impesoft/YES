using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                return Created("private", await _service.RegisterAsync(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserTokenDto>> LoginAsync(LoginDto dto)
        {
            try
            {
                return Ok(await _service.LoginAsync(dto.Email, dto.Password));
            }            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
