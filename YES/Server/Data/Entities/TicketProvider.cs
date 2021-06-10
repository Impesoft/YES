using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Entities
{
    public class TicketProvider : User
    {
        public virtual ICollection<Event> Events { get; set; }
    }
}