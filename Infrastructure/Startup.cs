using Infrastructure.Extensions.Jwt;
using Infrastructure.Extensions.Mapper;
using Infrastructure.Extensions.Mediator;
using Infrastructure.Extensions.Middleware;
using Infrastructure.Extensions.OpenApi;
using Infrastructure.Extensions.Persistence;
using Infrastructure.Extensions.Service;
using Infrastructure.Extensions.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddMediator();
        services.AddDomainServices();
        services.AddMongoContext(config);
        services.AddPesistence(config);
        services.AddMapper();
        services.AddValidator();
        services.AddJwtSettings(config);
        services.AddOpenApi();
    }
    
    public static void UseInfrastructure(this IApplicationBuilder builder,IWebHostEnvironment env)
    {
        builder.UseOpenApi(env);
        builder.UserErrorHandlingMiddleware();
        builder.UseAuthentication();
        builder.UseAuthorization();
    }
}