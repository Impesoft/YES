using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        [Required]
        public VenueDto Venue { get; set; }
        public TicketProviderDto TicketProvider { get; set; }
        public EventInfoDto EventInfo { get; set; }
        public ICollection<TicketCategoryDto> TicketCategories{ get; set; }
    }
}
