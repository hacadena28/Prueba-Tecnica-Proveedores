using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Adapters;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Validation;

public static class ValidationExtension
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        Assembly validationAssembly = Assembly.Load(ApiConstants.ApplicationProject);
        services.AddValidatorsFromAssembly(validationAssembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}