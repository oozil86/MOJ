using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MOJ.SharedKernel.Interceptors;

public sealed class SoftDeleteInterceptor
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var entries = eventData.Context.ChangeTracker.Entries<ISoftDelete>().Where(x => x.State == EntityState.Deleted);

        foreach (var entry in entries)
        {
            entry.CurrentValues.SetValues(entry.OriginalValues);
            entry.State = EntityState.Unchanged;
            entry.CurrentValues[nameof(ISoftDelete.IsDeleted)] = true;

            var referenceEntries = entry.References.Where(x => x.TargetEntry is not null &&
                                                               x.TargetEntry.Metadata.IsOwned() &&
                                                               x.TargetEntry.Metadata.ClrType.BaseType ==
                                                               typeof(ValueObject));

            foreach (var targetEntry in referenceEntries.Select(e => e.TargetEntry))
            {
                targetEntry!.CurrentValues.SetValues(targetEntry.OriginalValues);
                targetEntry!.State = EntityState.Unchanged;
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}

