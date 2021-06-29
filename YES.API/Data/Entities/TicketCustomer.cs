using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Api.Data.Entities
{
    public class TicketCustomer : User
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}