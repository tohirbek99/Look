using System.ComponentModel.DataAnnotations;

namespace Look.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
       public string? Slug { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
