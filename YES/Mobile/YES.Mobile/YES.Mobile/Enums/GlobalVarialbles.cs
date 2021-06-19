using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YES.Mobile.Dto;

namespace YES.Api.Enums
{
    public static class GlobalVarialbles
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static UserTokenDto LoggedInUser { get; set; }

    }
}
