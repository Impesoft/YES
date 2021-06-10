using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Models
{
    public class Ticket
    {
        public int Id;
        public int ticketCustomer_Id;
        public int event_id;
        public int price_id;
        public DateTime DateOfPurchase;
    }
}