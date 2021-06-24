using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class CustomerWithTicketsDto
    {
        public int Id { get; set; }

        public string GreetingName { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        public string LastName { get; set; }

        [MaxLength(34, ErrorMessage = "Maximum length is 34 characters.")]        
        public string BankAccount { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string PhoneNumber { get; set; }

        public virtual AddressDto Address { get; set; }

        public virtual ICollection<TicketDto> Tickets { get; set; }

    }
}
