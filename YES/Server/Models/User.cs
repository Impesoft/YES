using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Models
{
    public abstract class User
    {
        public int Id;
        public string BackAccount;
        public string Email;
        public string PhoneNumber;
        public Address Address;
    }
}