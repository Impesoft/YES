using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YES.Server.Data.Entities
{
    public abstract class User : EntityBase
    {
        public string BankAccount { get; set; }

        [Required]
        public string Email { get; set; }

        //[Required]
        public byte[]? PasswordHash { get; set; }

        //[Required]
        public byte[]? PasswordSalt { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Address Address { get; set; }
    }
}