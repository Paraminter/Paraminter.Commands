namespace Paraminter.Cqs.Composite;

using Moq;

using System.Collections.Generic;

internal interface IFixture<TCommand>
    where TCommand : ICommand
{
    public abstract ICommandHandler<TCommand> Sut { get; }

    public abstract Mock<IEnumerable<ICommandHandler<TCommand>>> ComponentsMock { get; }
}
