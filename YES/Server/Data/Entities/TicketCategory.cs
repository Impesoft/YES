using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Data.Entities
{
    public class TicketCategory : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int MaxAmount { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}