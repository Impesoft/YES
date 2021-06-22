namespace YES.Mobile.Dto
{
    public class TicketCategoryDto : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int MaxAmount { get; set; }
        public int AvailableAmount { get; set; }
    }
}