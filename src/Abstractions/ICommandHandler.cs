namespace Paraminter.Commands;

/// <summary>Handles commands.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    /// <summary>Handles the provided command.</summary>
    /// <param name="command">The handled command.</param>
    public abstract void Handle(TCommand command);
}
