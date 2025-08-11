//using AutoMapper;
//using MOJ.Domain.Repositories.Employee;
//using MOJ.SharedKernel.Abstractions.Messaging;
//using MOJ.SharedKernel.Abstractions.Persistence;
//using MOJ.SharedKernel.Contracts;

//namespace MOJ.Application.Features.Employee.UpdateEmployee;

//public static partial class UpdateEmployee
//{
//    internal sealed class Handler(IProductRepository repo,
//     IMapper mapper,
//     IUnitOfWork unitOfWork) : ICommandHandler<Request, Response>
//    {
//        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
//        {
//            var employee = await repo.GetByReferenceAsync(request.Reference, cancellationToken);
//            if (employee is null)
//                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Supplier), id: request.Reference);

//            var targetEmployee = mapper.Map(request, employee);
//            await unitOfWork.SaveChangesAsync(cancellationToken);

//            var result = mapper.Map<Response>(targetEmployee);

//            return Result.Success(result);
//        }
//    }
//}