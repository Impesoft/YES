using System;
using System.ComponentModel.DataAnnotations;
using YES.Shared.Helper;

namespace YES.Shared.Dto
{
    public class EventInfoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for your event.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event.")]
        public string Description { get; set; }

        //custom validator         
        [Date(ErrorMessage = "Please enter a valid date.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Please enter a website for your event.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        public string WebsiteUrl { get; set; }

        [Required(ErrorMessage = "Please enter a link to an image for your event.")]
        public string BannerImgUrl { get; set; }

    }
}
