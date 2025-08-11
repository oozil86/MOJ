using AutoMapper;
using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Product.UpdateProduct;

public static partial class UpdateProduct
{
    internal sealed class Handler(IProductRepository repo,
        IMapper mapper,  
        IUnitOfWork unitOfWork) : ICommandHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var product = await repo.GetByReferenceAsync(request.Reference, cancellationToken);
            if (product is null)
                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Product), id: request.Reference);

            var targetEmployee = mapper.Map(request, product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<Response>(targetEmployee);

            return Result.Success(result);
        }
    }
}