using System;
using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class EventInfoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for your event.")]
        [MinLength(1)]
        public string Name { get; set; }
        public string Description { get; set; }
        //[Range()]
        public DateTime EventDate { get; set; }        
        public string WebsiteUrl { get; set; }
        public string BannerImgUrl { get; set; }
    }
}
