using System.ComponentModel.DataAnnotations;

namespace YES.API.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}