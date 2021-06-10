using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Entities
{
    public class TicketCustomer : User
    {
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}