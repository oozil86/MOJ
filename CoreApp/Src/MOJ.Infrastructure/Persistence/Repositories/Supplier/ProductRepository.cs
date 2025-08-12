using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MOJ.Domain.DTOs.Supplier;
using MOJ.Domain.Entities;
using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Data;

namespace MOJ.Infrastructure.Persistence.Repositories.Supplier;

public class ProductRepository(CoreDbContext context, IMapper mapper) : BaseRepository<Product>(context)
    , IProductRepository
{
    public async Task<List<ProductDto>> GetMinimumProductsAsync(CancellationToken cancellationToken = default)
        => await context
        .Products
        .OrderByDescending(c => c.UnitsOnOrder)
        .Take(10)
        .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken: cancellationToken);

    public async Task<ProductDto?> GetProductAsync(Guid reference, CancellationToken cancellationToken = default)
        => await context
        .Products
        .Where(c => c.Reference == reference)
        .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
        .SingleOrDefaultAsync(cancellationToken);

    public async Task<List<ProductDto>> GetProductsByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        IQueryable<Product> query = context.Products;

        if (!string.IsNullOrEmpty(name))
            query = query.Where(p => p.Name.Contains(name));

        return await query
          .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
    }
    public async Task<List<ProductDto>> GetReOrderProductsAsync(int limit, CancellationToken cancellationToken = default)
        => await context
        .Products
        .Where(p => p.UnitsInStock < limit)
        .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
}
