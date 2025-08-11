using MOJ.Infrastructure.Persistence;
using MOJ.Infrastructure.Persistence.Repositories.Supplier;

namespace App.Tests.Builders.Repositories;

public class SupplierRepositoryBuilder
{
    public CoreDbContext DbContext { get;  set; }
    public SupplierRepositoryBuilder WithDbContext(CoreDbContext dbContext)
    {
        DbContext = dbContext;
        return this;
    }
    public SupplierRepository Build() 
    {
        DbContext ??= new CoreDbContextBuilder().Build();
        return new SupplierRepository(DbContext);
    }
}
