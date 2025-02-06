using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace VirtualWallet.Application;

public static class StartUp
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddValidatorsFromAssembly(assembly).AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
        return services;
    }
}