using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public virtual Address Address { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}