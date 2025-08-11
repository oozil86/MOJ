using MOJ.SharedKernel.Abstractions.Persistence;

namespace MOJ.SharedKernel.Contracts;

public abstract class Entity : IAuditableEntity, IEntity<int>, ISoftDelete
{
    private List<DomainEvent> _domainEvents = [];

    protected Entity() { }

    public int Id { get; init; }
    public Guid Reference { get; init; }

    public bool IsDeleted { get; private set; }

    public DateTimeOffset? DeletedAt { get; private set; }

    public Guid? DeletedBy { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastModifiedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public List<DomainEvent> GetDomainEvents()
    {
        return [.. _domainEvents];
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void RaiseDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void Delete(Guid? deletedBy)
    {
        IsDeleted = true;
        DeletedAt = DateTimeOffset.UtcNow;
        DeletedBy = deletedBy;
    }
}
