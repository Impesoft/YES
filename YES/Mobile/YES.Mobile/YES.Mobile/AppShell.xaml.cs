using System;
using System.Collections.Generic;
using Xamarin.Forms;
using YES.Mobile.ViewModels;
using YES.Mobile.Views;

namespace YES.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            //InitializeComponent();
            Routing.RegisterRoute(nameof(EventDetailPage), typeof(EventDetailPage));
            Routing.RegisterRoute(nameof(UserTicketsPage), typeof(UserTicketsPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}