using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UpWatch.EntityFramework.UnitOfWork;
using UpWatch.IoC.Module;
using UpWatch.Repositories.UnitOfWork;

namespace UpWatch.IoC;

public static class ServiceExtensions
{
    public static void RegisterModule(this IServiceCollection services, IModule module)
        => module.Configure(services);

    public static void RegisterModule<TModule>(this IServiceCollection services) where TModule : IModule
        => Activator.CreateInstance<TModule>().Configure(services);

    public static void AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddScoped(typeof(IUnitOfWork), typeof(EfUnitOfWork<TContext>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(EfUnitOfWork<>));
    }
}
