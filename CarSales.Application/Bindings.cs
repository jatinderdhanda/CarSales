using CarSales.Application.Abstractions.PipelineBehavior;
using Microsoft.Extensions.DependencyInjection;

namespace CarSales.Application;

public static class Bindings
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Bindings).Assembly);

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        return services;
    }
}