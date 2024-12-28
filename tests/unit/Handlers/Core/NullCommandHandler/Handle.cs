namespace Paraminter;

using Moq;

using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

public sealed class Handle
{
    [Fact]
    public async Task NullCommand_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<ICommand>();

        var result = await Record.ExceptionAsync(() => Target(fixture, null!, CancellationToken.None));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public async Task ValidCommand_DoesNotThrow()
    {
        var fixture = FixtureFactory.Create<ICommand>();
        var command = Mock.Of<ICommand>();

        var result = await Record.ExceptionAsync(() => Target(fixture, command, CancellationToken.None));

        Assert.Null(result);
    }

    private static async Task Target<TCommand>(
        IFixture<TCommand> fixture,
        TCommand command,
        CancellationToken cancellationToken)
        where TCommand : ICommand
    {
        await fixture.Sut.Handle(command, cancellationToken);
    }
}
