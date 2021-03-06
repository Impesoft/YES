using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YES.Shared.Enums;

namespace YES.Api.Data.Entities
{
    public class Event : EntityBase
    {
        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        public Venue Venue { get; set; }

        [Required]
        [ForeignKey("TicketProvider")]
        public int TicketProviderId { get; set; }

        public virtual TicketProvider TicketProvider { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual EventInfo EventInfo { get; set; }
        public virtual ICollection<TicketCategory> TicketCategories { get; set; }
    }
}