using System;
using System.ComponentModel.DataAnnotations;

namespace YES.Api.Data.Entities
{
    public class EventInfo : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }

        public DateTime? EventDate { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int MaxAvailableTickets { get; set; }

        [MaxLength(255)]
        public string WebsiteUrl { get; set; }
      
        [MaxLength(255)]
        public string BannerImgUrl { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}