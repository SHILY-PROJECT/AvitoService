using System.Reflection;
using AvitoService.Core.Common.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace AvitoService.Core;

public static class CoreRegistration
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddRepositories();
        
        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddRegistrationsByInterfaceType(typeof(IRepository));
    
    private static IServiceCollection AddRegistrationsByInterfaceType(this IServiceCollection services, Type registrationType)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x is { IsAbstract: false, IsClass: true } && x.GetInterface(registrationType.Name) == registrationType)
            .ToArray();

        foreach (var type in types)
        {
            foreach (var interfacesType in type.GetInterfaces())
            {
                services.AddScoped(interfacesType, type);
            }
        }

        return services;
    }
}