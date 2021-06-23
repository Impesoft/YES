namespace YES.Shared.Dto
{
    public class TicketPurchaseDto
    {
        public int TicketCustomerId { get; set; }
        public int EventId { get; set; }
        public TicketCategoryDto TicketCategory { get; set; }
        public int Amount { get; set; }
    }
}
