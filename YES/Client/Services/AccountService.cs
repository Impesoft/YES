using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;
using YES.Shared.GlobalClasses;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using Microsoft.JSInterop;
using YES.Client.Components;
using YES.Shared.Enums;
using System;

namespace YES.Client.Services
{
    public class AccountService : IAccountService
    {
        private HttpClient _http;
        public AccountService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> LogIn(LoginDto logindto)
        {
            return await _http.PostAsJsonAsync("/api/Account/Login", logindto);
        }

        public async Task<HttpResponseMessage> RegisterCustomer(RegisterCustomerDto registerCustomerDto)
        {
            return await _http.PostAsJsonAsync("/api/Account/Register", ConvertToGenericRegisterDto(registerCustomerDto));
        }
        public async Task<HttpResponseMessage> RegisterProvider(RegisterProviderDto registerProviderDto)
        {
            return await _http.PostAsJsonAsync("/api/Account/Register", ConvertToGenericRegisterDto(registerProviderDto));
        }

        public void LogOut()
        {
            GlobalVariables.LoggedInUser = null;
        }

        private RegisterDto ConvertToGenericRegisterDto(RegisterCustomerDto cDto)
        {
            return new RegisterDto
            {
                Email = cDto.Email,
                FirstName = cDto.FirstName,
                LastName = cDto.LastName,
                Password = cDto.Password,
                Role = cDto.Role
            };
        }
        private RegisterDto ConvertToGenericRegisterDto(RegisterProviderDto pDto)
        {
            return new RegisterDto
            {
                Email = pDto.Email,
                NameProvider = pDto.NameProvider,
                Password = pDto.Password,
                Role = pDto.Role
            };
        }
    }
}
