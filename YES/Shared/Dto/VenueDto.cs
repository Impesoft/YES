using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class VenueDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for your venue.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        public string Name { get; set; }

        [Range(1,1000000, ErrorMessage = "Please enter a maximum capacity")]
        public int Capacity { get; set; }

        [ValidateComplexType]
        public  AddressDto Address { get; set; }
    }
}
