using Microsoft.Extensions.DependencyInjection;
using UpWatch.IoC.Module;

namespace UpWatch.IoC;

public static class ServiceExtensions
{
    public static void RegisterModule(this IServiceCollection services, IModule module)
        => module.Configure(services);

    public static void RegisterModule<TModule>(this IServiceCollection services) where TModule : IModule
        => Activator.CreateInstance<TModule>().Configure(services);
}
