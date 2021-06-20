using System;
using System.Collections.Generic;
using System.Text;
using YES.Mobile.Enums;

namespace YES.Mobile.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        public string LocalUser { get; set; }

        public UserDetailViewModel()
        {
            Title = "User Details";
            LocalUser = GlobalVariables.LoggedInUser.Email;
        }
    }
}