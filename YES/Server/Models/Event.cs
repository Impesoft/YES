using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YES.Server.Enums;

namespace YES.Server.Models
{
    public class Event
    {
        public int Id;
        public int Venue_Id;
        public int TicketProvider_Id;
        public Status Status;
    }
}