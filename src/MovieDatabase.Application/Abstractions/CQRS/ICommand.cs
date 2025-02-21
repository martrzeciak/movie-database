using MediatR;
using MovieDatabase.Application.Common;

namespace MovieDatabase.Application.Abstractions.CQRS;

public interface ICommand : IRequest<Result<Unit>>, IBaseCommand
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}
