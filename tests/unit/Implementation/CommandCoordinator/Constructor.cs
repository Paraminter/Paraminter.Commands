namespace Paraminter;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullCommandFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand, object>(null!, Mock.Of<ICommandHandler<ICommand>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullCommandHandler_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand, object>(Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsCoordinator()
    {
        var result = Target(Mock.Of<object>(), Mock.Of<ICommandHandler<ICommand>>());

        Assert.NotNull(result);
    }

    private static CommandCoordinator<TCommand, TCommandFactory> Target<TCommand, TCommandFactory>(
        TCommandFactory commandFactory,
        ICommandHandler<TCommand> commandHandler)
        where TCommand : ICommand
    {
        return new CommandCoordinator<TCommand, TCommandFactory>(commandFactory, commandHandler);
    }
}
