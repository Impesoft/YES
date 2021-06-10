using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Entities
{
    public class TicketPrice
    {
        public int Id { get; set; }
        public string Category { get; set; }

        public int Price { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}