using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MOJ.SharedKernel.Contracts;
using MOJ.SharedKernel.Interceptors;

namespace MOJ.SharedKernel.Extensions;

public static class DbContextExtensions
{

    public static async Task PublishDomainEvents(this DbContext dbContext, IMediator mediator)
    {
        var entities = dbContext.ChangeTracker.Entries<Entity>().Select(x => x.Entity).Where(x => x.GetDomainEvents().Count > 0).ToList();

        foreach (var events in entities.Select(e => e.GetDomainEvents()))
        {
            foreach (var domainEvent in events)
            {
                await mediator.Publish(domainEvent);
            }
            events.Clear();
        }
    }

    public static void RegisterInterceptors(IServiceCollection services)
    {
        services.AddSingleton<SoftDeleteInterceptor>();
        services.AddScoped<AuditableEntityInterceptor>();
    }

    public static DbContextOptionsBuilder RegisterInterceptors(
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
