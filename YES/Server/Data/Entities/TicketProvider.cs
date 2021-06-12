using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Data.Entities
{
    public class TicketProvider : User
    {
        [Required]
        public string NameProvider { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}