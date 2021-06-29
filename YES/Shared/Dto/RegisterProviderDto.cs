using System.ComponentModel.DataAnnotations;
using YES.Shared.Enums;

namespace YES.Shared.Dto
{
    public class RegisterProviderDto
    {
        [Required(ErrorMessage = "Please enter your provider name.")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        public string NameProvider { get; set; }
        
        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(8)]
        public string Password { get; set; } 
        
        [Required]
        [CompareProperty(nameof(Password), ErrorMessage = "Passwords don't match, make sure CAPS is off :)")]
        public string ConfirmPassword { get; set; }

        [Required]
        public Roles Role { get; set; }
    }
}
