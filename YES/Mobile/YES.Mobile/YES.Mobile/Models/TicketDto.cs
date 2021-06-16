﻿using System;

namespace YES.Mobile.Dto
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }       
        public string CustomerLastName { get; set; }
        public string EventName { get; set; }
        public string VanueName { get; set; }
        public AddressDto VenueAddress { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public TicketCategoryDto TicketCategory { get; set; }
    }
}