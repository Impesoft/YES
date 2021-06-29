using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Minimum length is 4 characters.")]
        [MaxLength(8, ErrorMessage = "Maximum length is 8 characters.")]
        public string Password { get; set; }
    }
}
