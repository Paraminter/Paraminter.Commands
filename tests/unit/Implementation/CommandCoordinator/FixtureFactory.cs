namespace Paraminter;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TCommand, TCommandFactory> Create<TCommand, TCommandFactory>()
        where TCommand : ICommand
        where TCommandFactory : class
    {
        Mock<TCommandFactory> commandFactoryMock = new();
        Mock<ICommandHandler<TCommand>> commandHandlerMock = new();

        CommandCoordinator<TCommand, TCommandFactory> sut = new(commandFactoryMock.Object, commandHandlerMock.Object);

        return new Fixture<TCommand, TCommandFactory>(sut, commandFactoryMock, commandHandlerMock);
    }

    private sealed class Fixture<TCommand, TCommandFactory>
        : IFixture<TCommand, TCommandFactory>
        where TCommand : ICommand
        where TCommandFactory : class
    {
        private readonly ICommandCoordinator<TCommand, TCommandFactory> Sut;

        private readonly Mock<TCommandFactory> CommandFactoryMock;
        private readonly Mock<ICommandHandler<TCommand>> CommandHandlerMock;

        public Fixture(
            ICommandCoordinator<TCommand, TCommandFactory> sut,
            Mock<TCommandFactory> commandFactoryMock,
            Mock<ICommandHandler<TCommand>> commandHandlerMock)
        {
            Sut = sut;

            CommandFactoryMock = commandFactoryMock;
            CommandHandlerMock = commandHandlerMock;
        }

        ICommandCoordinator<TCommand, TCommandFactory> IFixture<TCommand, TCommandFactory>.Sut => Sut;

        Mock<TCommandFactory> IFixture<TCommand, TCommandFactory>.CommandFactoryMock => CommandFactoryMock;
        Mock<ICommandHandler<TCommand>> IFixture<TCommand, TCommandFactory>.CommandHandlerMock => CommandHandlerMock;
    }
}
