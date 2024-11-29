namespace Paraminter.Cqs.Composite;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
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
    public async Task ValidCommand_DispatchesToAllComponents()
    {
        var fixture = FixtureFactory.Create<ICommand>();
        var command = Mock.Of<ICommand>();

        IEnumerable<Mock<ICommandHandler<ICommand>>> componentMocks = [
            new Mock<ICommandHandler<ICommand>>(),
            new Mock<ICommandHandler<ICommand>>()
        ];

        var components = componentMocks.Select(static (componentHandlerMock) => componentHandlerMock.Object);

        fixture.ComponentsMock.Setup((enumerable) => enumerable.GetEnumerator()).Returns(components.GetEnumerator());

        await Target(fixture, command, CancellationToken.None);

        foreach (var componentMock in componentMocks)
        {
            componentMock.Verify((handler) => handler.Handle(command, It.IsAny<CancellationToken>()), Times.Once());
        }
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
