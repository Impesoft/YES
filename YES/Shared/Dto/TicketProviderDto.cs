using YES.Shared.Enums;

namespace YES.Shared.Dto
{
    public class TicketProviderDto
    {
        public int Id { get; set; }
        public string GreetingName { get; set; }
        public string NameProvider { get; set; }
        public string BankAccount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Roles Role { get; set; }
        public virtual AddressDto Address { get; set; }
    }
}
