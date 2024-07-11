namespace Paraminter.Commands.Coordinators;

/// <summary>Creates a command.</summary>
/// <typeparam name="TCommandFactory">The type used to create the command.</typeparam>
/// <typeparam name="TCommand">The type of the created command.</typeparam>
/// <param name="commandFactory">The factory used to create the command.</param>
/// <returns>The created command.</returns>
public delegate TCommand DCreateCommandThroughFactory<in TCommandFactory, out TCommand>(TCommandFactory commandFactory)
    where TCommand : ICommand;
