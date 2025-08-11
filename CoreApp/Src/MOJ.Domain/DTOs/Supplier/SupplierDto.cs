namespace MOJ.Domain.DTOs.Supplier;

public sealed record SupplierDto
{
    public Guid Reference { get; set; }
    public string Name { get; set; }
 }
