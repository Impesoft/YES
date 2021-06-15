using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YES.API.Data.Entities
{
    public abstract class User : EntityBase
    {
        [Required]
        public string BankAccount { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}