using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YES.Shared.Dto;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using Microsoft.JSInterop;
using YES.Client.Components;

namespace YES.Client.Services
{
    public class AccountService : IAccountService
    {
        private UserTokenDto LoggedInUser { get; set; }
        private string LoggedInUserJson { get; set; }
        private HttpClient _http;
        public AccountService(HttpClient http)
        {
            _http = http;            
        }

        public async Task<string> LogIn(LoginDto logindto)
        {
            var _loggedInUser = await _http.PostAsJsonAsync("/api/Account/Login", logindto);
            LoggedInUserJson = await _loggedInUser.Content.ReadAsStringAsync();

            if (_loggedInUser != null)
            {
                LoggedInUser = JsonConvert.DeserializeObject<UserTokenDto>(LoggedInUserJson);
            }

            return LoggedInUserJson;
        }

        public async Task RegisterUser(RegisterDto registerDto)
        {
            var registerResult = await _http.PostAsJsonAsync("/api/Account/Register", registerDto);
            var RegisterUserJson = await registerResult.Content.ReadAsStringAsync();
        }

        public UserTokenDto GetLoggedInUser()
        {
            return LoggedInUser;
        }

        public string GetLoggedInUserJson()
        {
            return LoggedInUserJson;
        }

        public void LogOut()
        {
            LoggedInUser = null;
        }
    }
}
