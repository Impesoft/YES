using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Api.Data.Entities
{
    public class TicketCustomer : User
    {        
        [MaxLength(50)]
        public string FirstName { get; set; }
                
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}