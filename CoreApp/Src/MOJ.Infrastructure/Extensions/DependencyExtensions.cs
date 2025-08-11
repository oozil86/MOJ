using MOJ.Infrastructure.Contracts;
using MOJ.Infrastructure.Persistence;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MOJ.Infrastructure.Extensions;

public static class DependencyExtensions
{
    public static IServiceCollection RegisterDbProvider(
         this IServiceCollection services,
            IConfiguration configuration
    )
    {
        RegisterInterceptors(services);
        services
         .AddDbContext<CoreDbContext>((sp, options) =>
             options
             .UseSqlServer(configuration.GetConnectionString(AppSettings.MOJCoreApp)!)
             .RegisterInterceptors(sp));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CoreDbContext>());


        return services;

    }

    private static void RegisterInterceptors(IServiceCollection services)
    {
        services.AddSingleton<SoftDeleteInterceptor>();
        services.AddScoped<AuditableEntityInterceptor>();
    }

    private static DbContextOptionsBuilder RegisterInterceptors(
        this DbContextOptionsBuilder dbContextOptionsBuilder,
        IServiceProvider serviceProvider)
    {
        dbContextOptionsBuilder.AddInterceptors(
              serviceProvider.GetRequiredService<SoftDeleteInterceptor>(),
              serviceProvider.GetRequiredService<AuditableEntityInterceptor>()
        );

        return dbContextOptionsBuilder;
    }
}
