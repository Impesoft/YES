using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YES.API.Data.Entities
{
    public class Address : EntityBase
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        public int? StreetNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("Venue")]
        public int? VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        [ForeignKey("TicketProvider")]
        public int? TicketProviderId { get; set; }

        public virtual TicketProvider TicketProvider { get; set; }

        [ForeignKey("TicketCustomer")]
        public int? TicketCustomerId { get; set; }

        public virtual TicketCustomer TicketCustomer { get; set; }
    }
}