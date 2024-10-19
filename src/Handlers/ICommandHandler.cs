namespace Paraminter.Cqs;

using System.Threading.Tasks;

/// <summary>Handles commands.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    /// <summary>Handles the provided command.</summary>
    /// <param name="command">The handled command.</param>
    /// <returns>A task representing the operation.</returns>
    public abstract Task Handle(TCommand command);
}
