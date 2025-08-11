using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Product.CreateProduct;

public static partial class CreateProduct
{
    public sealed record Request : ICommand<Response>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public Guid SupplierReference { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderLevel { get; set; }
        public string ProductUnit { get; set; }
    }
    public sealed record Response(Guid Reference);
}