using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Services;
using YES.Mobile.Views;
using Xamarin.Essentials;
using System.IO;
using YES.Mobile.Enums;

namespace YES.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLoggingIn { get; set; } = false;
        public Command LoginCommand { get; }
        private string LoggedInUserJson;
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
            IsLoggingIn = true;
            //  LoginDto loginInfo = new LoginDto();
            _accountService.LogIn(LoginInfo);

            GlobalVariables.LoggedInUser = Customer;
            if (GlobalVariables.LoggedInUser?.Id > 0)
            {
                IsLoggingIn = true;
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                IsLoggingIn = false;
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(UserDetailPage)}");
        }
    }
}