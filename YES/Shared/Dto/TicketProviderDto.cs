using System.ComponentModel.DataAnnotations;
using YES.Shared.Enums;

namespace YES.Shared.Dto
{
    public class TicketProviderDto
    {
        public int Id { get; set; }
        public string GreetingName { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string NameProvider { get; set; }

        [Required(ErrorMessage = "Please enter your bank account number name.")]
        [MaxLength(34, ErrorMessage = "Maximum length is 34 characters.")]
        public string BankAccount { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string PhoneNumber { get; set; }

        public Roles Role { get; set; }
        [ValidateComplexType]
        public virtual AddressDto Address { get; set; }
    }
}
