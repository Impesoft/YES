using System.ComponentModel.DataAnnotations;
using YES.Shared.Enums;

namespace YES.Api.Data.Entities
{
    public abstract class User : EntityBase
    {
        [MaxLength(50)]
        public string GreetingName { get; set; }

        [MaxLength(50)]
        public string BankAccount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(1024)]
        public byte[] PasswordHash { get; set; }

        [Required]
        [MaxLength(1024)]
        public byte[] PasswordSalt { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        public Roles Role { get; set; }

        public virtual Address Address { get; set; }
    }
}