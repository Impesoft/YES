using System;
using System.ComponentModel;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YES.Mobile.ViewModels;

namespace YES.Mobile.Views
{
    public partial class UserDetailPage : ContentPage
    {
        private UserDetailViewModel myVM;

        public UserDetailViewModel MyVM
        {
            get => myVM;
            set
            {
                myVM = value;
                OnPropertyChanged(nameof(MyVM));
            }
        }

        public UserDetailPage()
        {
            InitializeComponent();
            MyVM = new UserDetailViewModel();
            BindingContext = MyVM;
        }

        public void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.ShowPopup(new CancelSuccesfulPopup());
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            MyVM.LoadUserWithTickets();
        }
    }
}