using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Mapper;

public static class MapperExtensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.Load(ApiConstants.ApplicationProject));
        return services;
    }
}