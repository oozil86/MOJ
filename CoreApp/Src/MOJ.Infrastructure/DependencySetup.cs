using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOJ.Domain.Repositories.Supplier;
using MOJ.Infrastructure.Extensions;
using MOJ.Infrastructure.Persistence.Repositories.Supplier;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Infrastructure;

public static class DependencySetup
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterDbProvider(configuration);

        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        Clock.Initialize();

        return services;
    }
}
