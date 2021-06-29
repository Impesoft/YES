using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YES.Mobile.ViewModels;

namespace YES.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel thisVM;

        public LoginPage()
        {
            InitializeComponent();
            thisVM = new LoginViewModel();
            BindingContext = thisVM;
        }
    }
}