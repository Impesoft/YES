using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Models
{
    public class TicketCustomer : User
    {
        public List<Ticket> Tickets;
    }
}