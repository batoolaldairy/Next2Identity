using System.ComponentModel.DataAnnotations;

namespace Next2Identity.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
