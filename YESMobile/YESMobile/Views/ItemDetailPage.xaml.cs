using System.ComponentModel;
using Xamarin.Forms;
using YESMobile.ViewModels;

namespace YESMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}