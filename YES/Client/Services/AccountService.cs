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

namespace YES.Client.Services
{
    public class AccountService : IAccountService
    {
        private HttpClient _http;
        public AccountService(HttpClient http)
        {
            _http = http;            
        }

        public async Task<string> LogIn(LoginDto logindto)
        {
            var _loggedInUser = await _http.PostAsJsonAsync("/api/Account/Login", logindto);
            
            return await _loggedInUser.Content.ReadAsStringAsync(); 
        }

        public async Task<HttpResponseMessage> RegisterUser(RegisterDto registerDto)
        {
            if (registerDto.Role == Roles.TicketCustomer)
            {
                registerDto.NameProvider = "";
            }
            else if (registerDto.Role == Roles.TicketProvider)            
            {
                registerDto.FirstName = "";
                registerDto.LastName = "";
            }            

            return await _http.PostAsJsonAsync("/api/Account/Register", registerDto);            
        }        

        public void LogOut()
        {
            GlobalVariables.LoggedInUser = null;
        }
    }
}
