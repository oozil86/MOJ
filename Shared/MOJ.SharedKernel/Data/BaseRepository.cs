using Microsoft.EntityFrameworkCore;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;

namespace MOJ.SharedKernel.Data;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<T?> GetByReferenceAsync(Guid reference, CancellationToken cancellationToken = default)
       => await _dbSet.FirstOrDefaultAsync(c => c.Reference == reference, cancellationToken);


    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.ToListAsync(cancellationToken);


    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public void Delete(T entity)
        => _dbSet.Remove(entity);


}