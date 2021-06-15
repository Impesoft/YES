using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YES.API.Enums;

namespace YES.API.Data.Entities
{
    public class Event : EntityBase
    {
        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        [Required]
        [ForeignKey("TicketProvider")]
        public int TicketProviderId { get; set; }

        public virtual TicketProvider TicketProvider { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [ForeignKey("EventInfo")]
        public int EventInfoId { get; set; }

        public virtual EventInfo EventInfo { get; set; }
    }
}