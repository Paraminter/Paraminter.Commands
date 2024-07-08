namespace Paraminter;

using Moq;

using System;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullCommandCreationDelegate_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<ICommand, object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_HandlesCommand()
    {
        var fixture = FixtureFactory.Create<ICommand, object>();

        Mock<DCreateCommand<ICommand, object>> commandCreationDelegateMock = new();

        var command = Mock.Of<ICommand>();

        commandCreationDelegateMock.Setup((factory) => factory.Invoke(fixture.CommandFactoryMock.Object)).Returns(command);

        Target(fixture, commandCreationDelegateMock.Object);

        fixture.CommandHandlerMock.Verify((handler) => handler.Handle(command), Times.Once);
    }

    private static void Target<TCommand, TCommandFactory>(
        IFixture<TCommand, TCommandFactory> fixture,
        DCreateCommand<TCommand, TCommandFactory> commandCreationDelegate)
        where TCommand : ICommand
        where TCommandFactory : class
    {
        fixture.Sut.Handle(commandCreationDelegate);
    }
}
