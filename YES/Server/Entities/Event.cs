﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YES.Server.Enums;

namespace YES.Server.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }
        public int TicketProviderId { get; set; }
        public virtual TicketProvider TicketProvider { get; set; }
        public Status Status { get; set; }

        public virtual EventInfo EventInfo { get; set; }
    }
}