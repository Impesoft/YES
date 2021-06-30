using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class EventDto
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [ValidateComplexType]
        public VenueDto Venue { get; set; }

        [Required]
        public TicketProviderDto TicketProvider { get; set; }
        
        [ValidateComplexType]
        public EventInfoDto EventInfo { get; set; }

        [Required]
        [ValidateComplexType]
        public ICollection<TicketCategoryDto> TicketCategories{ get; set; }
    }
}
