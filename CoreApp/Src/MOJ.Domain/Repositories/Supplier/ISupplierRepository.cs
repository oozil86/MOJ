using MOJ.Domain.DTOs.Supplier;
using MOJ.SharedKernel.Abstractions.Persistence;

namespace MOJ.Domain.Repositories.Supplier;

public interface ISupplierRepository : IBaseRepository<Entities.Supplier>
{
    Task<SupplierDto?> GetLargestSuppliersAsync(CancellationToken cancellationToken = default);
    Task<List<SupplierDto>> GetSuppliersAsync(CancellationToken cancellationToken = default);
    Task<SupplierDto?> GetSupplierAsync(Guid reference, CancellationToken cancellationToken = default);
}
