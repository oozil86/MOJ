using Microsoft.Extensions.DependencyInjection;
using MOJ.SharedKernel.Behaviors;
using System.Reflection;

namespace MOJ.SharedKernel.Extensions;

public static class DependencyExtensions
{
    public static IServiceCollection RegisterMediatR(
    this IServiceCollection services,
    Assembly assemblyName)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assemblyName);

            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));

        });

        return services;
    }
}
