namespace YES.Mobile.Dto
{
    public class TicketProviderDto : ObservableObject
    {
        public int Id { get; set; }
        public string NameProvider { get; set; }
        public string BankAccount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }               
    }
}
