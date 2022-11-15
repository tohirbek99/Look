using System.ComponentModel.DataAnnotations;

namespace Look.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Location { get; set; }
        public string? ShipVia { get; set; }
        public string? Freight { get; set; }
        public string? ShipAddress { get; set; }
        public string? RequiredData { get; set; }
        public string? ShippedData { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<Costomer>? Costomers { get; set; }
        public ICollection<Order_Details>? Order_Details { get; set; }
    }
}
