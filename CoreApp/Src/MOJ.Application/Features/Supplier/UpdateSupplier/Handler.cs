using AutoMapper;
using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Supplier.UpdateSupplier;

public static partial class UpdateSupplier
{
    internal sealed class Handler(ISupplierRepository repo,
     IMapper mapper,
     IUnitOfWork unitOfWork) : ICommandHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var supplier = await repo.GetByReferenceAsync(request.Reference, cancellationToken);
            if (supplier is null)
                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Supplier), id: request.Reference);

            var targetSupplier = mapper.Map(request, supplier);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<Response>(targetSupplier);

            return Result.Success(result);
        }
    }
}