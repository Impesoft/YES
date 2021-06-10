using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Models
{
    public class TicketProvider : User
    {
        public List<Event> Events;
    }
}