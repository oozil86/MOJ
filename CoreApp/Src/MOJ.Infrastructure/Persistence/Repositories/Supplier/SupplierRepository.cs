using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Data;

namespace MOJ.Infrastructure.Persistence.Repositories.Supplier;

public class SupplierRepository(CoreDbContext context) : BaseRepository<Domain.Entities.Supplier>(context)
    , ISupplierRepository
{
}
