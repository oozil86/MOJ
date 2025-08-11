using AutoMapper;
using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Supplier.CreateSupplier;

public static partial class CreateSupplier
{
    internal sealed class Handler(ISupplierRepository repo,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : ICommandHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(
            Request request,
            CancellationToken cancellationToken)
        {
            var supplier = mapper.Map<Domain.Entities.Supplier>(request);
            await repo.AddAsync(supplier, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(new Response(supplier.Reference));
        }
    }
}
