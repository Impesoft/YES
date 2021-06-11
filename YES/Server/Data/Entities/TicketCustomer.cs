using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Data.Entities
{
    public class TicketCustomer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}