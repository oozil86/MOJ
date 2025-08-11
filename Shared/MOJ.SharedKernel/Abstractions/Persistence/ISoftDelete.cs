namespace MOJ.SharedKernel.Abstractions.Persistence;

public interface ISoftDelete
{
    public bool IsDeleted { get; }
    public DateTimeOffset? DeletedAt { get; }
    public Guid? DeletedBy { get; }
    void Delete(Guid? deletedBy);
}
