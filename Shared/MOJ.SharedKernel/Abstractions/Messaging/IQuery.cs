using MOJ.SharedKernel.Contracts;
using MediatR;

namespace MOJ.SharedKernel.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>, IBaseQuery;

public interface IQuery : IRequest<Result>, IBaseQuery;

public interface IBaseQuery;

