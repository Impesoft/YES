using System.ComponentModel;
using Xamarin.Forms;
using YES.Mobile.ViewModels;

namespace YES.Mobile.Views
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