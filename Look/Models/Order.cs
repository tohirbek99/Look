using System.ComponentModel.DataAnnotations;

namespace Look.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Count { get; set; }
        public string? Location { get; set; }
       
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Costomer>? Costomers { get; set; }
    }
}
