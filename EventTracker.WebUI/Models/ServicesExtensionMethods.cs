using EventTracker.DataSource;
using EventTracker.DataSource.Interfaces;

namespace EventTracker.WebUI.Models;

public static class ServicesExtensionMethods
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IEventDataSource, EventDataSource>();
        return services;
    }
}