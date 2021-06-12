using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YES.Server.Data.Entities
{
    public class Venue : EntityBase
    {
        [Required]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}