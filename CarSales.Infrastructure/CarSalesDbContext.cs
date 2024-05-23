using CarSales.Infrastructure.ModelConfiguration;
using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Infrastructure
{
    public class CarSalesDbContext : DbContext
    {
        public DbSet<CarDetails> CarDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=HY-000000005WLI\\SQLSERVER2022;UID=sa;PWD=Dhanda@1991;initial catalog=CarSales;Persist Security Info=True;Encrypt=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarDetailsTypeConfiguration());
        }
    }
}
