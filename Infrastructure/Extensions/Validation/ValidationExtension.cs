using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Validation;

public static class ValidationExtension
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        Assembly validationAssembly = Assembly.Load(ApiConstants.ApplicationProject);

        services.AddFluentValidation(c => { c.RegisterValidatorsFromAssembly(validationAssembly); });
        return services;
    }
}