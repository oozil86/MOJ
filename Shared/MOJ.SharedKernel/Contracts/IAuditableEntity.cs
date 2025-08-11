namespace MOJ.SharedKernel.Contracts;

public interface IAuditableEntity
{
    public DateTime CreatedAt { set; get; }
    public DateTime LastModifiedAt { set; get; }
    public Guid? CreatedBy { set; get; }
    public Guid? LastModifiedBy { set; get; }
}