using MediatR;


namespace BioldingBlocks.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse: notnull
    {
    }
}
