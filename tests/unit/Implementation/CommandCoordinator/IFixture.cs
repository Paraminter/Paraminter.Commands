namespace Paraminter;

using Moq;

internal interface IFixture<TCommand, TCommandFactory>
    where TCommand : ICommand
    where TCommandFactory : class
{
    public abstract ICommandCoordinator<TCommand, TCommandFactory> Sut { get; }

    public abstract Mock<TCommandFactory> CommandFactoryMock { get; }
    public abstract Mock<ICommandHandler<TCommand>> CommandHandlerMock { get; }
}
