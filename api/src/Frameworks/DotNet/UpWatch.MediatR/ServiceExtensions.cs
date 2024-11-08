using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace UpWatch.MediatR;

public static class ServiceExtensions
{
    public static void AddMediatRWithFluentValidation(this IServiceCollection services, params Type[] assemblyPointerTypes)
    {
        services.AddMediatR(assemblyPointerTypes);
        services.AddValidatorsFromAssembly(assemblyPointerTypes.First().Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
