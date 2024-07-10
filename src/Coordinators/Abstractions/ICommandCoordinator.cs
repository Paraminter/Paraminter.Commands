namespace Paraminter.Commands.Coordinators;

/// <summary>Coordinates creation and handling of commands.</summary>
/// <typeparam name="TCommand">The type of the created and handled commands.</typeparam>
/// <typeparam name="TCommandFactory">The type used to create commands.</typeparam>
public interface ICommandCoordinator<TCommand, TCommandFactory>
    where TCommand : ICommand
{
    /// <summary>Creates and handles a command.</summary>
    /// <param name="commandCreationDelegate">Creates the command to be handled.</param>
    public abstract void Handle(
        DCreateCommand<TCommand, TCommandFactory> commandCreationDelegate);
}
