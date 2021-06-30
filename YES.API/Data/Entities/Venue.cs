using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Api.Data.Entities
{
    public class Venue : EntityBase
    {
        public virtual Address Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int Capacity { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}