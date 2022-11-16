using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Look.DBContexts.Validation;

namespace Look.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string? ProductName { get; set; }

        public string? Slug { get; set; }

        [Required, MinLength(4, ErrorMessage = "Minimum length a 4")]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public string? Image { get; set; }
                
        [NotMapped]
        [FileExtention]
        public IFormFile? ImageUploud { get; set; }
        
        public int CategoryId { get; set; }
        [Required,Range(1, double.MaxValue, ErrorMessage = "Please enter a value")]
        public virtual Category? Category { get; set; }
        public ICollection<Order_Details>? Order_Details { get; set; }

    }
}
