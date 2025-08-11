using AutoMapper;
using MOJ.Domain.Repositories.Supplier;
using MOJ.SharedKernel.Abstractions.Messaging;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Application.Features.Product.GetProducts;

public static partial class GetProducts
{
    internal sealed class Handler(IProductRepository repo,
         IMapper mapper) : IQueryHandler<Request, Response>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var products = await repo.GetProductsByNameAsync(request.Name, cancellationToken);
            var result = mapper.Map<Response>(products);
            return Result.Success(result);
        }
    }
}