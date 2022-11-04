using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Look.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? PhoneNamber { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Orders { get; set; }

        public ICollection<Category>? Categories { get; set; }
    }
}
