using Microsoft.AspNetCore.Mvc;
using MOJ.Domain.DTOs.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Product.GetProduct;

public static partial class GetProduct
{
    public sealed record Request : IQuery<Response>
    {
        [FromRoute]
        public Guid Reference { set; get; }
    }
    public sealed record Response(ProductDto? Product);
}