namespace MOJ.SharedKernel.Contracts;

public interface ICurrentUser
{
    Guid UserReference { get; }
    string? Email { get; }
    string? FirstName { get; }
    string? LastName { get; }
    Guid TenantReference { get; }
    bool IsManager { get; }
}
