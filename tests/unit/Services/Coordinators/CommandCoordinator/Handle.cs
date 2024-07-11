namespace Paraminter.Commands.Coordinators;

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

        Mock<DCreateCommandThroughFactory<object, ICommand>> commandCreationDelegateMock = new();

        var command = Mock.Of<ICommand>();

        commandCreationDelegateMock.Setup((factory) => factory.Invoke(fixture.CommandFactoryMock.Object)).Returns(command);

        Target(fixture, commandCreationDelegateMock.Object);

        fixture.CommandHandlerMock.Verify((handler) => handler.Handle(command), Times.Once);
    }

    private static void Target<TCommand, TCommandFactory>(
        IFixture<TCommand, TCommandFactory> fixture,
        DCreateCommandThroughFactory<TCommandFactory, TCommand> commandCreationDelegate)
        where TCommand : ICommand
        where TCommandFactory : class
    {
        fixture.Sut.Handle(commandCreationDelegate);
    }
}
