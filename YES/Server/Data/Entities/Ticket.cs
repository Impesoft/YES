﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Data.Entities
{
    public class Ticket : EntityBase
    {
        public int TicketCustomerId { get; set; }

        public virtual TicketCustomer TicketCustomer { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public virtual TicketPrice TicketPrice { get; set; }
    }
}