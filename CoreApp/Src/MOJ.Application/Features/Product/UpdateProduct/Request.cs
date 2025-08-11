using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Product.UpdateProduct;

public static partial class UpdateProduct
{
    public sealed record Request : ICommand<Response>
    {
        public Guid Reference { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderLevel { get; set; }
        public string ProductUnit { get; set; }
    }
    public sealed record Response
    {
        public Guid Reference { get; set; }
       
    }
}