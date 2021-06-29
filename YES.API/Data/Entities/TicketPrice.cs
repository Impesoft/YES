using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YES.Api.Data.Entities
{
    public class TicketPrice : EntityBase
    {        
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        public int Price { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}