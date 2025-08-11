using MOJ.Domain.DTOs.Supplier;
using MOJ.Domain.Entities;
using MOJ.SharedKernel.Abstractions.Persistence;

namespace MOJ.Domain.Repositories.Supplier;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<List<ProductDto>> GetProductsByNameAsync(string name, CancellationToken cancellationToken = default);
    public Task<List<ProductDto>> GetReOrderProductsAsync(int limit, CancellationToken cancellationToken = default);
    public Task<List<ProductDto>> GetMinimumProductsAsync(CancellationToken cancellationToken = default);
}
