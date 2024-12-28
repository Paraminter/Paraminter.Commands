namespace Paraminter.Composite;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles commands by dispatching them to multiple handlers.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class CommandHandlerComposite<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly IEnumerable<ICommandHandler<TCommand>> Components;

    /// <summary>Instantiates a handler of commands, which dispatches them to multiple handlers.</summary>
    /// <param name="components">The handlers to which the commands are dispatched.</param>
    public CommandHandlerComposite(
        IEnumerable<ICommandHandler<TCommand>> components)
    {
        Components = components ?? throw new System.ArgumentNullException(nameof(components));
    }

    async Task ICommandHandler<TCommand>.Handle(
        TCommand command,
        CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        List<Task> tasks = [];

        foreach (var component in Components)
        {
            tasks.Add(component.Handle(command, cancellationToken));
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}
