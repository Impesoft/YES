using YES.Mobile.Enums;

namespace YES.Mobile.Dto
{
    public class UserTokenDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string NameProvider { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
        public Roles Role { get; set; }
    }
}