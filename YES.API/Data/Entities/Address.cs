using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Api.Data.Entities
{
    public class Address : EntityBase
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        public string? StreetNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("Venue")]
        public int? VenueId { get; set; }

        [ForeignKey("TicketProvider")]
        public int? TicketProviderId { get; set; }

        [ForeignKey("TicketCustomer")]
        public int? TicketCustomerId { get; set; }
    }
}