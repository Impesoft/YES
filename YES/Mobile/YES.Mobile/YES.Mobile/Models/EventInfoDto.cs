using System;

namespace YES.Mobile.Models
{
    public class EventInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string WebsiteUrl { get; set; }
        public string BannerImgUrl { get; set; }
    }
}