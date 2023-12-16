using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Persistence;

public static class MongoContextExtensions
{
    public static IServiceCollection AddMongoContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(typeof(MongoContext<>));
        return services;
    }
}