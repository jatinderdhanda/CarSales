using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore;
using CarSales.Domain.Abstraction;
using MediatR;
using CarSales.Infrastructure.ModelConfiguration;

namespace CarSales.Infrastructure;

public class CarSalesDbContext : DbContext, IUnitOfWork
{
    public CarSalesDbContext(DbContextOptions<CarSalesDbContext> options)
        : base(options)
    {
    }
    public DbSet<CarDetail> CarDetails => Set<CarDetail>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarSalesDbContext).Assembly);
        modelBuilder
           .ApplyConfiguration(new BookingEntityConfiguration());
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
