using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace YES.Mobile.Dto
{
    public class CustomerWithTicketsDto : ObservableObject
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BankAccount { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual AddressDto Address { get; set; }

        public virtual ObservableCollection<TicketDto> Tickets { get; set; }
    }
}