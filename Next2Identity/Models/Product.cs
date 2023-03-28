using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Next2Identity.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Quantity { get; set; }
        public double price { get; set;}

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? category { get; set; }


    }
}
