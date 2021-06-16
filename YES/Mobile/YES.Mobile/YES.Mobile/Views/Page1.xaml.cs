using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YES.Mobile.Models;

namespace YES.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClientHandler insecureHandler = handler;
            HttpClient httpClient = new HttpClient(insecureHandler);

            var resultJson = await httpClient.GetStringAsync("https://vaxxapi.azurewebsites.net/api/Vaccine/ForBodyPart/Head");

            var resultVaccines = JsonConvert.DeserializeObject<Vaccine[]>(resultJson);

            ListOfVaccines.ItemsSource = resultVaccines;
        }

    }
}