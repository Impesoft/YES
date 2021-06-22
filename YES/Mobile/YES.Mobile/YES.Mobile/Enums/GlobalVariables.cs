using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using YES.Mobile.Dto;

namespace YES.Mobile.Enums
{
    public static class GlobalVariables
    {
        public static string FileName = Path.Combine(FileSystem.AppDataDirectory, "LocalStorage");
        public static UserTokenDto LoggedInUser { get; set; }

    }
}
