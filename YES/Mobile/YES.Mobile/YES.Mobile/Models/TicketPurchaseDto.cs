using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YES.Mobile.Dto
{
    public class TicketPurchaseDto : ObservableObject
    {
        public int TicketCustomerId { get; set; }
        public int EventId { get; set; }
        public TicketCategoryDto TicketCategory { get; set; }
        public int Amount { get; set; }
    }
}