using Microsoft.AspNetCore.Mvc;
using MOJ.Domain.DTOs.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Supplier.GetSupplier;

public static partial class GetSupplier
{
    public sealed record Request : IQuery<Response>
    {
        [FromRoute]
        public Guid Reference { set; get; }
    }
    public sealed record Response(SupplierDto? Supplier);
}