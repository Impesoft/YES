using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YES.Mobile.Dto;
using YES.Mobile.Enums;
using YES.Mobile.Services;
using YES.Mobile.Views;

namespace YES.Mobile
{
    public partial class App : Application
    {
        private string LoggedInUserJson;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IEventService, EventService>();
            DependencyService.Register<IAccountService, AccountService>();
            DependencyService.Register<ICustomerService, CustomerService>();

            LoadUserIfExists();
            if (GlobalVariables.LoggedInUser != null)
            {
                var stream = GlobalVariables.LoggedInUser.Token;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = jsonToken as JwtSecurityToken;
                var expiryDate = tokenS.ValidTo;
                if (DateTime.Now > expiryDate)
                {
                    //destroy file
                    File.Delete(GlobalVariables.FileName);
                    GlobalVariables.LoggedInUser = null;
                }
                else
                {
                    MainPage = new AppShell();
                }
            }
            else
            {
                //GlobalVariables.LoggedInUser = new UserTokenDto();
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void LoadUserIfExists()
        {
            if (File.Exists(GlobalVariables.FileName))
            {
                LoggedInUserJson = File.ReadAllText(GlobalVariables.FileName);

                if (LoggedInUserJson != "Invalid input")
                {
                    GlobalVariables.LoggedInUser = JsonConvert.DeserializeObject<UserTokenDto>(LoggedInUserJson);
                }
            }
        }
    }
}