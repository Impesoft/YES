using System.ComponentModel.DataAnnotations;

namespace YES.Shared.Dto
{
    public class TicketCategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for this category")]
        public string Name { get; set; }

        public double Price { get; set; }

        [Range(1, 1000000, ErrorMessage = "Please enter a maximum amount")]
        public int MaxAmount { get; set; }

        public int AvailableAmount { get; set; }
    }
}
