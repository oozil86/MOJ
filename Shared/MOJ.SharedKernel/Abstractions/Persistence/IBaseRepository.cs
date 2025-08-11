using MOJ.SharedKernel.Contracts;

namespace MOJ.SharedKernel.Abstractions.Persistence;

public interface IBaseRepository<T> where T : Entity
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByReferenceAsync(Guid reference, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Delete(T entity);
}