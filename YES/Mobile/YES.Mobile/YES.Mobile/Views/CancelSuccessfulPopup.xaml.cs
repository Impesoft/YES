﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YES.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CancelSuccessfulPopup : Popup
    {
        public CancelSuccessfulPopup()
        {
            InitializeComponent();
        }
    }
}