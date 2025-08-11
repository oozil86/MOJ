using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MOJ.SharedKernel.Contracts;
using MOJ.SharedKernel.Extensions;

namespace MOJ.SharedKernel.Interceptors;

public class AuditableEntityInterceptor(ICurrentUser user) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        var addedEntries = context.ChangeTracker.Entries<IAuditableEntity>().Where(x => x.IsAdded());
        var modifiedEntries = context.ChangeTracker.Entries<IAuditableEntity>().Where(x => x.IsModified());
        var deletedEntries = context.ChangeTracker.Entries<IAuditableEntity>().Where(x => x.IsDeleted());

        foreach (var currentValues in addedEntries.Select(e => e.CurrentValues))
        {
            currentValues[nameof(Entity.CreatedAt)] = Clock.Now;
            currentValues[nameof(Entity.CreatedBy)] = user?.UserReference;
            currentValues[nameof(Entity.LastModifiedAt)] = Clock.Now;
            currentValues[nameof(Entity.LastModifiedBy)] = user?.UserReference;
        }

        foreach (var currentValues in modifiedEntries.Select(e => e.CurrentValues))
        {
            currentValues[nameof(Entity.LastModifiedAt)] = Clock.Now;
            currentValues[nameof(Entity.LastModifiedBy)] = user?.UserReference;
        }
        foreach (var currentValues in deletedEntries.Select(e => e.CurrentValues))
        {
            currentValues[nameof(Entity.DeletedAt)] = Clock.Now;
            currentValues[nameof(Entity.DeletedBy)] = user?.UserReference;
        }
    }
}
