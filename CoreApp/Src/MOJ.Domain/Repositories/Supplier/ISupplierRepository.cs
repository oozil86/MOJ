using MOJ.Domain.DTOs.Supplier;
using MOJ.SharedKernel.Abstractions.Persistence;

namespace MOJ.Domain.Repositories.Supplier;

public interface ISupplierRepository : IBaseRepository<Entities.Supplier>
{
    Task<SupplierDto?> GetLargestSuppliersAsync(CancellationToken cancellationToken = default);
}
