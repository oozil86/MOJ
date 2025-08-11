using MOJ.Domain.DTOs.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Statistics.GetGetDashboardStatistics;

public static partial class GetGetDashboardStatistics
{
    public sealed record Request : IQuery<Response>;
    public sealed record Response(List<ProductDto> MinimumProducts
        ,List<ProductDto> ReorderProducts
        ,SupplierDto? LargestSupplier);
}