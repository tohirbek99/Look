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
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FastFood> FastFoods { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FastFood>()
                .HasOne(e => e.Employees)
                .WithMany(c => c.FastFoods)
                .HasForeignKey(e => e.EmploeeId);

            modelBuilder.Entity<Drink>()
                .HasOne(e=>e.Employees)
                .WithMany(d=>d.Drinks)
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
