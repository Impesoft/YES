﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YES.Shared.Dto
{
    public class TicketPurchaseDto
    {
        public int TicketCustomerId { get; set; }
        public int EventId { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

    }
}