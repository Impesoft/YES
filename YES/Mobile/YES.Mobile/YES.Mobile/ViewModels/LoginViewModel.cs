using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Services;
using YES.Mobile.Views;

namespace YES.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private IAccountService _accountService { get; set; }
    private UserTokenDto Customer { get; set; }
        public LoginDto LoginInfo { get; set; } = new LoginDto();

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            _accountService = new AccountService();
        }

        private void OnLoginClicked(object obj)
        {
          //  LoginDto loginInfo = new LoginDto();
            _accountService.LogIn(LoginInfo);


            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync($"//{nameof(UserDetailPage)}");
        }


    private async Task LogIn()
    {
        await _accountService.LogIn(LoginInfo);
        Customer = _accountService.GetLoggedInUser();           

      //  await JSRuntime.InvokeVoidAsync("localStorage.setItem", "user", _accountService.LoggedInUserJson);
    }
        /*
         * 



    [Inject]
    private IAccountService _accountService { get; set; }


    // delete => await JSRuntime.InvokeAsync<string>("localStorage.removeItem", "name");
         * */
    }
}