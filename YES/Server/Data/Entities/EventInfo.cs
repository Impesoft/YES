using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Data.Entities
{
    public class EventInfo : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EventDate { get; set; }

        public int MaxAvailableTickets { get; set; }

        public string WebsiteUrl { get; set; }

        public string BannerImgUrl { get; set; }

        public int EventId { get; set; }
    }
}