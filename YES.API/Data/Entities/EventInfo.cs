using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Api.Data.Entities
{
    public class EventInfo : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? EventDate { get; set; }

        [Required]
        public int MaxAvailableTickets { get; set; }

        [Required]
        public string WebsiteUrl { get; set; }

        [Required]
        public string BannerImgUrl { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}