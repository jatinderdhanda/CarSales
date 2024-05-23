using Microsoft.Extensions.DependencyInjection;

namespace CarSales.Infrastructure
{
    public static class Bindings
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<CarSalesDbContext>();
            return services;
        }

    }
}