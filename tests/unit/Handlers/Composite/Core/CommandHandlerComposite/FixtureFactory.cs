namespace Paraminter.Cqs.Composite;

using Moq;

using System.Collections.Generic;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<IEnumerable<ICommandHandler<TCommand>>> componentsMock = new();

        var sut = new CommandHandlerComposite<TCommand>(componentsMock.Object);

        return new Fixture<TCommand>(sut, componentsMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<IEnumerable<ICommandHandler<TCommand>>> ComponentsMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<IEnumerable<ICommandHandler<TCommand>>> componentsMock)
        {
            Sut = sut;

            ComponentsMock = componentsMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<IEnumerable<ICommandHandler<TCommand>>> IFixture<TCommand>.ComponentsMock => ComponentsMock;
    }
}
