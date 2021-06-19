﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YES.Mobile.Services;
using YES.Mobile.Views;

namespace YES.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IEventService, EventService>();
            DependencyService.Register<IAccountService, AccountService>();

            MainPage = new LoginPage();
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
    }
}