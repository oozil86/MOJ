namespace MOJ.SharedKernel.Abstractions.Persistence;

public interface IEntity<out TId>
{
    public TId Id { get; }
    public Guid Reference { get; }

}
