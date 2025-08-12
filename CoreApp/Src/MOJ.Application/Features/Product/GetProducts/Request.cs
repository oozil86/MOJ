using Microsoft.AspNetCore.Mvc;
using MOJ.Domain.DTOs.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Product.GetProducts;

public static partial class GetProducts
{
    public sealed record Request : IQuery<Response>
    {
        [FromQuery]
        public string? Name { set; get; }
    }
    public sealed record Response
    {
        public List<ProductDto> Products { set; get; }
    }


}
