using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Supplier.DeleteSupplier;


public static partial class DeleteSupplier
{
    internal sealed class Handler(ISupplierRepository repo,
        IUnitOfWork unitOfWork)
        : ICommandHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var supplier = await repo.GetByReferenceAsync(request.Reference, cancellationToken);

            if (supplier is null)
                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Supplier), id: request.Reference);

            repo.Delete(supplier);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(new Response(true));
        }
    }
}

