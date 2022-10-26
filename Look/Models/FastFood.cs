using System.ComponentModel.DataAnnotations;

namespace Look.Models
{
    public class FastFood
    {
        [Key]
        public int FoodId { get; set; }
        public string? FoodName { get; set;}
        public string? Price { get; set; }
        
        public int EmploeeId { get; set; }
        public virtual Employee? Employees { get; set; }
    }
}
