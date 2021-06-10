
using YES.Server.Data.Entities;

namespace YES.Server.Entities
{
    public abstract class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BankAccount { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Address Address { get; set; }
    }
}