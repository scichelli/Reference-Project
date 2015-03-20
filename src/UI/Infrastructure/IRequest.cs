namespace Headspring.Labs.UI.Infrastructure
{
    public interface IRequest<out TResponse> { }

    public interface IRequestHandler<in TRequest, out TResponse>
        where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest message);
    } 
}