using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YES.Api.Data.Entities
{
    public class Address : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        
        [MaxLength(20)]        
        public string StreetNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [ForeignKey("Venue")]
        public int? VenueId { get; set; }

        [ForeignKey("TicketProvider")]
        public int? TicketProviderId { get; set; }

        [ForeignKey("TicketCustomer")]
        public int? TicketCustomerId { get; set; }
    }
}