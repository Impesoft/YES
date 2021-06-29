using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YES.Api.Data.Entities
{
    public class TicketCategory : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int MaxAmount { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}