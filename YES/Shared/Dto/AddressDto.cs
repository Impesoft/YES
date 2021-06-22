using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your street")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter your postal code.")]
        [MaxLength(10, ErrorMessage = "Maximum length is 10 characters.")]
        [MinLength(3, ErrorMessage = "Minimum length is 3 characters.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your street number")]
        [MaxLength(5, ErrorMessage = "Maximum length is 5 characters.")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Country")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Country { get; set; }      
    }
}
