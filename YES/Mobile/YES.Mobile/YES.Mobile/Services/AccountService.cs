using System.Net.Http;
using System.Threading.Tasks;
using YES.Shared.Dto;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using YES.Mobile.Dto;
using System.Text;

namespace YES.Mobile.Services
{
    public class AccountService : IAccountService
    {
        private UserTokenDto LoggedInUser { get; set; }
        public string LoggedInUserJson { get; set; }
        private HttpClient _http;
        public AccountService()
        {
            _http = new HttpClient();
        }

        public async Task LogIn(LoginDto logindto)
        {
            string logindtoJson = JsonConvert.SerializeObject(logindto);
            StringContent myStringContent = new StringContent(logindtoJson.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");

            var _loggedInUser = await _http.PostAsync("/api/Account/Login", myStringContent);

            //HttpResponseHeader.SetCookie(new (_loggedInUser);
            HttpResponseMessage message = _http.PostAsync("/api/Account/Login", myStringContent).GetAwaiter().GetResult();
            string responseContent = message.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            LoggedInUserJson = await _loggedInUser.Content.ReadAsStringAsync();

            if (_loggedInUser != null)
            {              
                LoggedInUser = JsonConvert.DeserializeObject<UserTokenDto>(LoggedInUserJson);

                int test = 1; test++;
            }           
        }

        //public async Task<CustomerWithTicketsDto> GetCustomerByIdAsync(int id)
        //{
        //    var _customer = await _http.GetFromJsonAsync<CustomerWithTicketsDto>("api/TicketCustomer/IncludeTickets/" + id);

        //    return _customer;
        //}


        public UserTokenDto GetLoggedInUser()
        {
            return LoggedInUser;
        }

    

        //responseString
    }
}
