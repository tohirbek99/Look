using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Look.Models
{
    public class Order_Details
    {
        public int Id { get; set; }
        public string? UnitPrice { get; set; }
        public string? DisCount { get; set; }
        public int Quantity { get; set; }
        
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
