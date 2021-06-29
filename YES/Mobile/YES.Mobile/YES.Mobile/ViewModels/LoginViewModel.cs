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
using System.Windows.Input;

namespace YES.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        private bool showLoginFields = true;
        private Task logingIn;

        public bool ShowLoginFields
        {
            get => showLoginFields;

            set
            {
                showLoginFields = value;
                OnPropertyChanged(nameof(ShowLoginFields));
            }
        }

        private bool isLoggingIn;

        public bool IsLoggingIn
        {
            get => isLoggingIn;

            set
            {
                isLoggingIn = value;
                ShowLoginFields = !isLoggingIn;
                OnPropertyChanged(nameof(IsLoggingIn));
            }
        }

        private bool loginFailed;

        public bool LoginFailed
        {
            get => loginFailed;

            set
            {
                loginFailed = value;
                OnPropertyChanged(nameof(LoginFailed));
            }
        }

        public Command LoginCommand { get; }

        private IAccountService _accountService { get; set; }

        public LoginDto LoginInfo { get; set; } = new LoginDto();

        public LoginViewModel()
        {
            File.Delete(GlobalVariables.FileName);
            GlobalVariables.LoggedInUser = null;
            LoginCommand = new Command(OnLoginClicked);
            _accountService = new AccountService();
        }

        private async void OnLoginClicked(object obj)
        {
            IsLoggingIn = true;
            LoginFailed = false;

            await Task.Run(() => Login());

            if (GlobalVariables.LoggedInUser?.Id > 0 && GlobalVariables.LoggedInUser?.Role == Roles.TicketCustomer)
            {
                IsLoggingIn = true;
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                LoginFailed = true;
                File.Delete(GlobalVariables.FileName);
                IsLoggingIn = false;
            }
        }

        private void Login()
        {
            logingIn = _accountService.LogIn(LoginInfo);
            while (!logingIn.IsCompleted)
            {
                //wait
            }
        }
    }
}