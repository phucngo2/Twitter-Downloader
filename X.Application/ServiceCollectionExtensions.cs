using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using X.Application.Services.TwitterServices;

namespace X.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ITwitterService, TwitterService>();

        return services;
    }
}
