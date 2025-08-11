//using MOJ.Domain.Repositories.Employee;
//using MOJ.SharedKernel.Abstractions.Messaging;
//using MOJ.SharedKernel.Abstractions.Persistence;
//using MOJ.SharedKernel.Contracts;

//namespace MOJ.Application.Features.Employee.DeleteEmployee;


//public static partial class DeleteEmployee
//{
//    internal sealed class Handler(IProductRepository repo,
//        IUnitOfWork unitOfWork)
//        : ICommandHandler<Request, Response>
//    {
//        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
//        {
//            var employee = await repo.GetByReferenceAsync(request.Reference, cancellationToken);
//            if (employee is null)
//                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Supplier), id: request.Reference);

//            repo.Delete(employee);
//            await unitOfWork.SaveChangesAsync(cancellationToken);

//            return Result.Success(new Response(true));
//        }
//    }
//}

