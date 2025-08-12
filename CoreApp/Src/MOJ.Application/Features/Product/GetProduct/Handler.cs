using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Product.GetProduct;

public static partial class GetProduct
{
    internal sealed class Handler(IProductRepository repo)
        : IQueryHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(
            Request request,
            CancellationToken cancellationToken)
        {
            var suppliers = await repo.GetProductAsync(request.Reference, cancellationToken);
            return Result.Success(new Response(suppliers));
        }
    }
}
