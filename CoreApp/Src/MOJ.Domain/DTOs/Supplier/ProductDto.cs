namespace MOJ.Domain.DTOs.Supplier;

public sealed record ProductDto
{
    public Guid Reference { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int UnitsInStock { get; set; }
    public int UnitsOnOrder { get; set; }
    public Guid SupplierReference { get; set; }
    public decimal UnitPrice { get; set; }
    public int ReorderLevel { get; set; }
    public string ProductUnit { get; set; }
}
