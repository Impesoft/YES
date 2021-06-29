using System;

namespace YES.Mobile.Dto
{
    public class TicketDto : ObservableObject
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string EventName { get; set; }
        public string VenueName { get; set; }
        public DateTime EventDate { get; set; }

        public AddressDto VenueAddress { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public TicketCategoryDto TicketCategory { get; set; }
    }
}