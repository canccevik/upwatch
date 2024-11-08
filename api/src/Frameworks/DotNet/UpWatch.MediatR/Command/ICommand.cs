using MediatR;

namespace UpWatch.MediatR.Command;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
