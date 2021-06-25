using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using YES.Mobile.Enums;
using YES.Mobile.ViewModels;
using YES.Mobile.Views;

namespace YES.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EventDetailPage), typeof(EventDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            File.Delete(GlobalVariables.FileName);
            await Current.GoToAsync("//LoginPage");
        }
    }
}