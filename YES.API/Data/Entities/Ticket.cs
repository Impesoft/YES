using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Api.Data.Entities
{
    public class Ticket : EntityBase
    {
        [Required]
        [ForeignKey("TicketCustomer")]
        public int TicketCustomerId { get; set; }

        public virtual TicketCustomer TicketCustomer { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        [ForeignKey("TicketCategory")]
        public int TicketCategoryId { get; set; }

        public virtual TicketCategory TicketCategory { get; set; }
    }
}