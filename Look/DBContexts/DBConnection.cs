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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Category>()
                .HasOne(e=>e.Employees)
                .WithMany(d=>d.Categories)
                .HasForeignKey(e => e.EmploeeId);
            
            modelBuilder.Entity<Employee>()
                .HasOne(o=>o.Orders)
                .WithMany(e=>e.Employees)
                .HasForeignKey(o=>o.OrderId);

            modelBuilder.Entity<Costomer>()
                .HasOne(o=>o.Orders)
                .WithMany(c=>c.Costomers)
                .HasForeignKey(o=>o.OrderId);
        }


    }
}
