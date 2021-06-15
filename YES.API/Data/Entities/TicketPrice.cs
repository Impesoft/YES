using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YES.API.Data.Entities
{
    public class TicketPrice : EntityBase
    {
        [Required]
        public string Category { get; set; }

        [Required]
        public int Price { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}