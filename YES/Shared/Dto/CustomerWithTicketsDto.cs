using System.Collections.Generic;

namespace YES.Shared.Dto
{
    public class CustomerWithTicketsDto
    {       
        public string FirstName { get; set; }       
        public string LastName { get; set; }
      
        public string BankAccount { get; set; }
        
        public string Email { get; set; }    
        
        public string PhoneNumber { get; set; }   

        public virtual AddressDto Address { get; set; }
        public virtual ICollection<TicketDto> Tickets { get; set; }

    }
}
