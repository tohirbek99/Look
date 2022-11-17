using Look.DBContexts.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Look.Models.ViewModel
{
    public class ProductsViewModel
    {
        [Required(ErrorMessage = "Please enter a value")]
        public string ProductName { get; set; }


        [Required, MinLength(4, ErrorMessage = "Minimum length a 4")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }


        [NotMapped]
        [FileExtention]
        public IFormFile ImageUpload { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You mast choose a category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
