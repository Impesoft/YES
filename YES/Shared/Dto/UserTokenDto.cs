using YES.Shared.Enums;

namespace YES.Shared.Dto
{
    public class UserTokenDto
    {
        public int Id { get; set; }
        public string GreetingName { get; set; }
        public string Email { get; set; }       
        public string Token { get; set; }
        public Roles Role { get; set; }
    }
}