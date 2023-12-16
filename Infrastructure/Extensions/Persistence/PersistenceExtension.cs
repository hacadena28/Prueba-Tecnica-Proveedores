using Domain.Ports;
using Infrastructure.Adapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure.Extensions.Persistence;

public static class PersistenceExtension
{
    public static IServiceCollection AddPesistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IMongoDatabase>((sp) =>
        {
            
            var client = new MongoClient("mongodb://localhost:27017");
            return client.GetDatabase("Supplier");
            
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}