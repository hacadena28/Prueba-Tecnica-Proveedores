using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Infrastructure.Extensions.OpenApi;

public static class OpenApiExtensions
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1.0.0", new OpenApiInfo
            {
                Version = "v1.0.0",
                Title = "Supplier management API",
                Description = "API for supplier management in the mongo database",
                Contact = new OpenApiContact
                {
                    Name = "Heli Cadena",
                    Email = "Dev.helicadena@gmail.com",
                    Url = new Uri("https://www.linkedin.com/in/helicadena/")
                },
            });


            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization usa el header con el esquema Bearer. Ejemplo: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Api.xml"));
            c.ExampleFilters();
        });
        return services;
    }

    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (!env.IsDevelopment()) return app;
        app.UseSwagger();
        app.UseSwaggerUI(
            c => c.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "Supplier API v1"));
        return app;
    }
}