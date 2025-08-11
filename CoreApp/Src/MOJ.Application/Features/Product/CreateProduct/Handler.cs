using AutoMapper;
using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;
namespace MOJ.Application.Features.Product.CreateProduct;

public static partial class CreateProduct
{
    internal sealed class Handler(
        ISupplierRepository repo,
        IUnitOfWork unitOfWork,
        IMapper mapper) : ICommandHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var supplier = await repo.GetByReferenceAsync(request.SupplierReference, cancellationToken);

            if (supplier is null)
                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Supplier), id: request.SupplierReference);

            var product = mapper.Map<Domain.Entities.Product>(request);
            supplier.AddProduct(product);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(new Response(product.Reference));
        }
    }
}