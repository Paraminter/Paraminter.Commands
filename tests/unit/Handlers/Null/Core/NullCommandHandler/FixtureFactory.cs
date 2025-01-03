namespace Paraminter;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        var sut = new NullCommandHandler<TCommand>();

        return new Fixture<TCommand>(sut);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        public Fixture(
            ICommandHandler<TCommand> sut)
        {
            Sut = sut;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;
    }
}
