namespace YES.Mobile.Models
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public VenueDto Venue { get; set; }
        public TicketProviderDto TicketProvider { get; set; }
        public EventInfoDto EventInfo { get; set; }
    }
}