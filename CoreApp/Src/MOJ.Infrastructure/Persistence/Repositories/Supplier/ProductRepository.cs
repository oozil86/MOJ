using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Data;

namespace MOJ.Infrastructure.Persistence.Repositories.Supplier;

public class ProductRepository(CoreDbContext context) : BaseRepository<Domain.Entities.Product>(context)
    , IProductRepository
{
}
