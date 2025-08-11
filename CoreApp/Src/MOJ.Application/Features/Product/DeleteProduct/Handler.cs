using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Product.DeleteProduct;


public static partial class DeleteProduct
{
    internal sealed class Handler(IProductRepository repo,
        IUnitOfWork unitOfWork)
        : ICommandHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var product = await repo.GetByReferenceAsync(request.Reference, cancellationToken);
            if (product is null)
                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Product), id: request.Reference);

            repo.Delete(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(new Response(true));
        }
    }
}

