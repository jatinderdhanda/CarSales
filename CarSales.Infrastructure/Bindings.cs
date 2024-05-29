using CarSales.Application.Abstractions.Clock;
using CarSales.Domain.Abstraction;
using CarSales.Domain.Interfaces;
using CarSales.Infrastructure.Clock;
using CarSales.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarSales.Infrastructure
{
    public static class Bindings
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<CarSalesDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<CarSalesDbContext>();
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICarDetailsRepository, CarDetailsRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CarSalesDbContext>());
            return services;
        }

    }
}