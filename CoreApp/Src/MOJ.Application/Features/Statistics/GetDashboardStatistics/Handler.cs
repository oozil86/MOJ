using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Statistics.GetGetDashboardStatistics;

public static partial class GetGetDashboardStatistics
{
    internal sealed class Handler(
        ISupplierRepository supplierRepo,
        IProductRepository productRepo) 
        : IQueryHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var largestSupplier = await supplierRepo
                .GetLargestSuppliersAsync(cancellationToken);

            var minimumProducts = await productRepo
                .GetMinimumProductsAsync(cancellationToken);

            var reOrderProducts = await productRepo
                .GetReOrderProductsAsync(10, cancellationToken);

            return Result.Success(new Response(minimumProducts, reOrderProducts, largestSupplier));
        }
    }
}