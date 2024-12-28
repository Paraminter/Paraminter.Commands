namespace Paraminter.Composite;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullComponents_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target(Mock.Of<IEnumerable<ICommandHandler<ICommand>>>());

        Assert.NotNull(result);
    }

    private static CommandHandlerComposite<TCommand> Target<TCommand>(IEnumerable<ICommandHandler<TCommand>> components)
        where TCommand : ICommand
    {
        return new CommandHandlerComposite<TCommand>(components);
    }
}
