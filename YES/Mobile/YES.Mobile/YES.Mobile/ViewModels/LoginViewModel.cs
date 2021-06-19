using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using YES.Mobile.Views;

namespace YES.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync($"//{nameof(UserDetailPage)}");
        }
    }
}