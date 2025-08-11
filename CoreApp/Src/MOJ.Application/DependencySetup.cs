using Microsoft.Extensions.DependencyInjection;
using MOJ.SharedKernel.Extensions;
using System.Reflection;

namespace MOJ.Application;

public static class DependencySetup
{
    public static Assembly Assembly => typeof(DependencySetup).Assembly;

    public static IServiceCollection RegisterApplicationServices(
        this IServiceCollection services)
    {
        services.AddCustomAutoMapper(Assembly);
        services.RegisterMediatR(Assembly);
        services.AddCustomFluentValidation(Assembly);


        return services;
    }
}
