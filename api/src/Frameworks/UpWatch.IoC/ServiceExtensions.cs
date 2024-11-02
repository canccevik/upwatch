using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC.Module;

namespace UpWatch.IoC;

public static class ServiceExtensions
{
    public static void RegisterModule(this IServiceCollection services, IModule module)
        => module.Configure(services);

    public static void RegisterModule<TModule>(this IServiceCollection services) where TModule : IModule
        => Activator.CreateInstance<TModule>().Configure(services);

    public static void RegisterModules(this IServiceCollection services, Assembly assembly)
    {
        foreach (var moduleType in assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Module.Module))))
        {
            if (Activator.CreateInstance(moduleType) is Module.Module module)
                module.Configure(services);
        }
    }

    public static void RegisterAllTypes<TService>(
        this IServiceCollection services,
        ServiceLifetime lifetimeScope,
        params Type[] assemblyMarkerTypes)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assemblyMarkerTypes);

        var serviceType = typeof(TService);
        var implementationTypes = assemblyMarkerTypes
            .Select(t => t.Assembly)
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => serviceType.IsAssignableFrom(type) && !type.GetTypeInfo().IsInterface &&
                           !type.GetTypeInfo().IsAbstract);

        foreach (var implementationType in implementationTypes)
        {
            switch (lifetimeScope)
            {
                case ServiceLifetime.Scoped:
                    services.AddScoped(serviceType, implementationType);
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton(serviceType, implementationType);
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(serviceType, implementationType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lifetimeScope), lifetimeScope, null);
            }
        }
    }
}
