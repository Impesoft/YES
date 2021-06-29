using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace YES.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public AboutViewModel()
        {
        }
    }
}