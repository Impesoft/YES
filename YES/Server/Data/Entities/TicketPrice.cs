using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Data.Entities
{
    public class TicketPrice : EntityBase
    {
        public string Category { get; set; }

        public int Price { get; set; }
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}