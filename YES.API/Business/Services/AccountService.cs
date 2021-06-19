using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos;
using YES.Api.Data.Repos.Interfaces;
using YES.Shared.Dto;
using YES.Shared.Enums;

namespace YES.Api.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ITicketCustomerRepo _ticketCustomerRepo;
        private readonly ITicketProviderRepo _ticketProviderRepo;
        public AccountService(IUserService userService, ITokenService tokenService, ITicketCustomerRepo ticketCustomerRepo, ITicketProviderRepo ticketProviderRepo)
        {
            _userService = userService;
            _tokenService = tokenService;
            _ticketCustomerRepo = ticketCustomerRepo;
            _ticketProviderRepo = ticketProviderRepo;
        }
        public async Task<UserTokenDto> RegisterAsync(RegisterDto dto)
        {
            if (await _userService.UserExistsAsync(dto.Email))
            {
                throw new UnauthorizedAccessException("Email already exists, please try again or login");
            }

            switch (dto.Role)
            {               
                case Roles.TicketCustomer:

                    TicketCustomer ticketCustomer = CreateTicketCustomer(dto);
                    await _ticketCustomerRepo.AddEntityAsync(ticketCustomer);
                    return CreateUserTokenDto(ticketCustomer);

                case Roles.TicketProvider:

                    TicketProvider ticketProvider = CreateTicketProvider(dto);
                    await _ticketProviderRepo.AddEntityAsync(ticketProvider);
                    return CreateUserTokenDto(ticketProvider);

                default:

                    throw new InvalidOperationException("Role was not valid");                    
            }
        }

        public async Task<UserTokenDto> LoginAsync(string eMail, string password)
        {
            User user = await _userService.GetUserByEmailAsync(eMail);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid input");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (!hash.SequenceEqual(user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid input");
            }

            return CreateUserTokenDto(user);
        }

        private UserTokenDto CreateUserTokenDto(User user)
        {
            return new UserTokenDto
            {
                Id = user.Id,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role = user.Role
            };
        }

        private TicketCustomer CreateTicketCustomer(RegisterDto dto)
        {
            using var hmac = new HMACSHA512();

            TicketCustomer ticketCustomer = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key,
                Role = dto.Role
            };

            return ticketCustomer;
        }
        private TicketProvider CreateTicketProvider(RegisterDto dto)
        {
            using var hmac = new HMACSHA512();

            TicketProvider ticketProvider = new()
            {
                NameProvider = dto.NameProvider,
                Email = dto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key,
                Role = dto.Role
            };

            return ticketProvider;
        }

    }
}
