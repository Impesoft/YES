using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Api.Data.Entities
{
    public class TicketProvider : User
    {
        [Required]
        public string NameProvider { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}