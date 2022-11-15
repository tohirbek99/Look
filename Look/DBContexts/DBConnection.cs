using Look.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace Look.DBContexts
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options)
            : base(options)
        {

        }
        public DbSet<Costomer> Costomers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order_Details> Orders_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Details>()
                .HasOne(o => o.Order)
                .WithMany(d => d.Order_Details)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId);
            
            modelBuilder.Entity<Order_Details>()
                .HasOne(e => e.Product)
                .WithMany(c => c.Order_Details)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<Costomer>()
                .HasOne(o=>o.Orders)
                .WithMany(c=>c.Costomers)
                .HasForeignKey(o=>o.OrderId);
        }


    }
}
