using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore;
using CarSales.Domain.Abstraction;

namespace CarSales.Infrastructure
{
    public class CarSalesDbContext : DbContext, IUnitOfWork
    {
        public DbSet<CarDetails> CarDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;Integrated Security=True;initial catalog=CarSales;Persist Security Info=True;Encrypt=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarSalesDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Concurrency exception occurred.", ex);
            }
        }
    }
}
