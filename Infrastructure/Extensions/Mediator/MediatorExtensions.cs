using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Mediator;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.Load(ApiConstants.ApplicationProject),Assembly.GetExecutingAssembly());

        return services;
    }
}