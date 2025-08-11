//using AutoMapper;
//using MOJ.Domain.Repositories.Employee;
//using MOJ.SharedKernel.Abstractions.Messaging;
//using MOJ.SharedKernel.Contracts;

//namespace MOJ.Application.Features.Employee.GetEmployee;

//public static partial class GetEmployee
//{
//    internal sealed class Handler(IProductRepository repo,
//         IMapper mapper) : IQueryHandler<Request, Response>
//    {
//        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
//        {
//            var employee = await repo.GetByReferenceAsync(request.Reference, cancellationToken);
//            if (employee is null)
//                return DomainResults.NotFound<Response>(entity: nameof(Domain.Entities.Supplier), id: request.Reference);
//            var result = mapper.Map<Response>(employee);
//            return Result.Success(result);
//        }
//    }
//}