namespace Paraminter;

/// <summary>Creates a command.</summary>
/// <typeparam name="TCommand">The type of the created command.</typeparam>
/// <typeparam name="TCommandFactory">The type used to create the command.</typeparam>
/// <param name="commandFactory">The factory used to create the command.</param>
/// <returns>The created command.</returns>
public delegate TCommand DCreateCommand<out TCommand, in TCommandFactory>(TCommandFactory commandFactory)
    where TCommand : ICommand;
