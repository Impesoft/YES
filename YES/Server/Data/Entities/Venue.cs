using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YES.Server.Data.Entities
{
    public class Venue : EntityBase
    {
        public virtual Address Address { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}