using System.ComponentModel.DataAnnotations;

namespace YES.Server.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}