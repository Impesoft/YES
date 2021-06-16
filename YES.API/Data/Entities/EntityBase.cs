using System.ComponentModel.DataAnnotations;

namespace YES.Api.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}