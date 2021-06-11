using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Data.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public int? StreetNumber { get; set; }

        public string Country { get; set; }

        public int? VenueId { get; set; }
        public virtual Venue Venue { get; set; }
        public int? TicketProviderId { get; set; }
        public virtual TicketProvider TicketProvider { get; set; }
        public int? TicketCustomerId { get; set; }
        public virtual TicketCustomer TicketCustomer { get; set; }
    }
}