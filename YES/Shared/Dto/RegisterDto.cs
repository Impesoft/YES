﻿using System.ComponentModel.DataAnnotations;
using YES.Shared.Enums;

namespace YES.Shared.Dto
{
    public class RegisterDto
    {
        public string NameProvider { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(8)]
        public string Password { get; set; }

        [Required]
        public Roles  Role { get; set; }
    }
}
