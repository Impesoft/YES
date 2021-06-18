
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YES.Mobile.ViewModels;

namespace YES.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        public EventDetailPage()
        {
            InitializeComponent();
            BindingContext = new EventDetailViewModel();
        }
    }
}