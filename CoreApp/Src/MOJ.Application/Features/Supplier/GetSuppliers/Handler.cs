using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Supplier.GetSuppliers;

public static partial class GetSuppliers
{
    internal sealed class Handler(ISupplierRepository repo)
        : IQueryHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(
            Request request,
            CancellationToken cancellationToken)
        {
            var suppliers = await repo.GetSuppliersAsync(cancellationToken);
            return Result.Success(new Response(suppliers));
        }
    }
}
