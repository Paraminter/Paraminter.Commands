namespace Paraminter;

internal interface IFixture<TCommand>
    where TCommand : ICommand
{
    public abstract ICommandHandler<TCommand> Sut { get; }
}
