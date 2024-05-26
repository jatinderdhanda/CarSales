using CarSales.Infrastructure.ModelConfiguration;
using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore;
using CarSales.Domain.ModelConfiguration;

namespace CarSales.Infrastructure
{
    public class CarSalesDbContext : DbContext
    {
        public DbSet<CarDetails> CarDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;Integrated Security=True;initial catalog=CarSales;Persist Security Info=True;Encrypt=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarDetailsTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
        }
    }
}
