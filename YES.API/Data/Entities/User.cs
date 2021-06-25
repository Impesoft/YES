using System.ComponentModel.DataAnnotations;
using YES.Shared.Enums;

namespace YES.Api.Data.Entities
{
    public abstract class User : EntityBase
    {
        public string GreetingName { get; set; }

        public string BankAccount { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public string PhoneNumber { get; set; }

        public Roles Role { get; set; }

        public virtual Address Address { get; set; }
    }
}