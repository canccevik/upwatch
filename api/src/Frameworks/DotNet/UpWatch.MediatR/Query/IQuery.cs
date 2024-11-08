using MediatR;

namespace UpWatch.MediatR.Query;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
