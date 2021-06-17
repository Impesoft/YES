using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITicketCustomerRepo _ticketCustomerRepo;
        private readonly ITokenService _tokenService;
        public AccountService(ITicketCustomerRepo ticketCustomerRepo, ITokenService tokenService)
        {
            _ticketCustomerRepo = ticketCustomerRepo;
            _tokenService = tokenService;
        }
        public async Task<UserTokenDto> RegisterAsync(RegisterDto dto)
        {
            if (await _ticketCustomerRepo.UserExistsAsync(dto.Email))
            {
                throw new UnauthorizedAccessException("Email already exists, please try again or login");
            }
            using var hmac = new HMACSHA512();

            TicketCustomer ticketCustomer = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };

            await _ticketCustomerRepo.AddEntityAsync(ticketCustomer);

            return CreateUserTokenDto(ticketCustomer);
        }

        public async Task<UserTokenDto> LoginAsync(string eMail, string password)
        {
            TicketCustomer ticketCustomer = await _ticketCustomerRepo.GetTicketCustomerByEmailAsync(eMail);

            if (ticketCustomer == null)
            {
                throw new UnauthorizedAccessException("Invalid Email");
            }

            using var hmac = new HMACSHA512(ticketCustomer.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (!hash.SequenceEqual(ticketCustomer.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            return CreateUserTokenDto(ticketCustomer);
        }

        private UserTokenDto CreateUserTokenDto(TicketCustomer ticketCustomer)
        {
            return new UserTokenDto
            {
                Id = ticketCustomer.Id,
                Email = ticketCustomer.Email,
                Token = _tokenService.CreateToken(ticketCustomer)
            };
        }

    }
}
