using MOJ.Domain.DTOs.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Supplier.GetSuppliers;

public static partial class GetSuppliers
{
    public sealed record Request : IQuery<Response>;
    public sealed record Response(List<SupplierDto> Suppliers);
}