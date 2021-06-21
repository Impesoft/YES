using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using YES.Mobile.Dto;
using System.Text;
using Xamarin.Essentials;
using System.IO;
using YES.Mobile.Enums;

namespace YES.Mobile.Services
{
    public class AccountService : IAccountService
    {
        //private UserTokenDto LoggedInUser { get; set; }
        private HttpResponseMessage message;

        public string LoggedInUserJson { get; set; }
        private HttpClient _http;

        public AccountService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            _http = new HttpClient(insecureHandler);
        }

        public async Task LogIn(LoginDto logindto)
        {
            string logindtoJson = JsonConvert.SerializeObject(logindto);
            StringContent myStringContent = new StringContent(logindtoJson.ToString(), Encoding.UTF8, "application/json");

            //message = await _http.PostAsync("https://yesapi.azurewebsites.net/api/Account/Login", myStringContent);
            //HttpResponseHeader.SetCookie(new (_loggedInUser);
            message = _http.PostAsync("https://yesapi.azurewebsites.net/api/Account/Login", myStringContent).GetAwaiter().GetResult();
            string responseContent = message.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            LoggedInUserJson = await message.Content.ReadAsStringAsync();

            // store userjson
            if (LoggedInUserJson != "Invalid input")
            {
                File.WriteAllText(GlobalVariables.FileName, LoggedInUserJson);

                if (LoggedInUserJson != null)
                {
                    GlobalVariables.LoggedInUser = JsonConvert.DeserializeObject<UserTokenDto>(LoggedInUserJson);
                }
            }
        }

        //public async Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id)
        //{
        //    //   var _customer = await _http.GetFromJsonAsync<CustomerWithTicketsDto>("api/TicketCustomer/IncludeTickets/" + id);
        //    var content = await _http.GetStringAsync("api/TicketCustomer/IncludeTickets/" + id);
        //    return JsonConvert.DeserializeObject<CustomerWithTicketsDto>(content);
        //}

        //public UserTokenDto GetLoggedInUser()
        //{
        //    return LoggedInUser;
        //}

        //responseString
    }
}