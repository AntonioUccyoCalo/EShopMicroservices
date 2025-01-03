using MediatR;


namespace BioldingBlocks.CQRS
{

    //Command senza valore di tirno, Unit per MartinR è come il void
    public interface ICommandHandler<in Tcommand>
        : ICommandHandler<Tcommand,Unit>
        where Tcommand : ICommand<Unit>
            { }

    //Command sencon valore di ritorno
    public interface ICommandHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse> 
        where TCommand : ICommand<TResponse> 
        where TResponse : notnull
    {
    }
}
