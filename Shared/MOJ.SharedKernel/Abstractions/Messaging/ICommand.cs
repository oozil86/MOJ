using MOJ.SharedKernel.Contracts;
using MediatR;

namespace MOJ.SharedKernel.Abstractions.Messaging;

public interface ICommand: IRequest<Result>, IBaseCommand;

public interface ICommand<TReponse>: IRequest<Result<TReponse>>, IBaseCommand;
public interface IBaseCommand;
