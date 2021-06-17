using System.Collections.Generic;

namespace YES.Mobile.Dto
{
    public class EventDto : ObservableObject
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public VenueDto Venue { get; set; }
        public TicketProviderDto TicketProvider { get; set; }
        public EventInfoDto EventInfo { get; set; }
        public ICollection<TicketCategoryDto> TicketCategories{ get; set; }
    }
}
