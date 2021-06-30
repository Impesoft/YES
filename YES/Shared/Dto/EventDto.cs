using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YES.Shared.Helper;

namespace YES.Shared.Dto
{
    public class EventDto
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [CantBeNull]
        [ValidateComplexType]
        public VenueDto Venue { get; set; }

        [Required]
        public TicketProviderDto TicketProvider { get; set; }
        
        [ValidateComplexType]
        public EventInfoDto EventInfo { get; set; }

        [CantBeNullOrEmptyList(ErrorMessage = "Please enter a ticket category")]
        public ICollection<TicketCategoryDto> TicketCategories{ get; set; }
    }
}
