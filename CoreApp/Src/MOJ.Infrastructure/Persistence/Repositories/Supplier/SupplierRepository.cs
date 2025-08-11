using Microsoft.EntityFrameworkCore;
using MOJ.Domain.DTOs.Supplier;
using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Data;

namespace MOJ.Infrastructure.Persistence.Repositories.Supplier;

public class SupplierRepository(CoreDbContext context) : BaseRepository<Domain.Entities.Supplier>(context)
    , ISupplierRepository
{
    public async Task<SupplierDto?> GetLargestSuppliersAsync(CancellationToken cancellationToken = default)
    {
        var countDic = await context
            .Suppliers
            .Include(s => s.Products)
            .Select(c => new { c.Reference, c.Name, ProductCount = c.Products.Count() })
            .GroupBy(c => c.Reference)
            .ToDictionaryAsync(c => c.Key, c => c.FirstOrDefault(), cancellationToken: cancellationToken);

        return countDic
                .OrderByDescending(c => c.Value?.ProductCount)
                .Select(c => new SupplierDto { Name = c.Value?.Name, Reference = c.Key })
                .FirstOrDefault();
    }
}
