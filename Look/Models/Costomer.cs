using System.ComponentModel.DataAnnotations;

namespace Look.Models
{
    public class Costomer
    {
        [Key]
        public int CostomerId { get; set; }
        public string? CostemerName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNamber { get; set; }
        public string? Fax { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Orders { get; set; }
    }
}
