namespace Paraminter;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsHandler()
    {
        var result = Target<ICommand>();

        Assert.NotNull(result);
    }

    private static NullCommandHandler<TCommand> Target<TCommand>()
        where TCommand : ICommand
    {
        return new NullCommandHandler<TCommand>();
    }
}
