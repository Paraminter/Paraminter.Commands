namespace Paraminter;

using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles command by doing nothing.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class NullCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    /// <summary>Instantiates a handler of commands, which does nothing.</summary>
    public NullCommandHandler() { }

    async Task ICommandHandler<TCommand>.Handle(
        TCommand command,
        CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        await Task.CompletedTask.ConfigureAwait(false);
    }
}
