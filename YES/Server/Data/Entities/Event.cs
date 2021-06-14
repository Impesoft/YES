using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YES.Server.Enums;

namespace YES.Server.Data.Entities
{
    public class Event : EntityBase
    {
        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        [Required]
        [ForeignKey("TicketProvider")]
        public int TicketProviderId { get; set; }

        public virtual TicketProvider TicketProvider { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<TicketCategory> TicketCategories { get; set; }
        public virtual EventInfo EventInfo { get; set; }
    }
}