using MediatR;


namespace BioldingBlocks.CQRS
{
    //Command senza valore di tirno, Unit per MartinR è come il void
    public interface ICommand : ICommand<Unit> { }

    //Restituisce un risultato
    public interface ICommand<out TResponse>: IRequest<TResponse>
    {
    }
}
