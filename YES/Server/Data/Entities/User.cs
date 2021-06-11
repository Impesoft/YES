using System.ComponentModel.DataAnnotations;

namespace YES.Server.Data.Entities
{
    public abstract class User : EntityBase
    {
        public string BankAccount { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Address Address { get; set; }
    }
}