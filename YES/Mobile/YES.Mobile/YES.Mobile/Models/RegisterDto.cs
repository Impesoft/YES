using Xamarin.CommunityToolkit.ObjectModel;
using YES.Mobile.Enums;

namespace YES.Shared.Dto
{
    public class RegisterDto : ObservableObject
    {
        public string NameProvider { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }
    }
}