using System;
using System.ComponentModel;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YES.Mobile.Views
{
    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage()
        {
            InitializeComponent();
        }

        public void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.ShowPopup(new CancelSuccesfulPopup());
        }
    }
}