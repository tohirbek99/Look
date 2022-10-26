using System.ComponentModel.DataAnnotations;

namespace Look.Models
{
    public class Drink
    {

        [Key]
        public int DrinkId { get; set; }
        public string? DrinkName { get; set; }
        public string? Volume { get; set; }
        public string? Price { get; set; }

        public int EmploeeId { get; set; }
        public virtual Employee? Employees { get; set; }
    }
}
