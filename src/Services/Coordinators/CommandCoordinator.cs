namespace Paraminter.Commands.Coordinators;

using Paraminter.Commands.Handlers;

using System;

/// <inheritdoc cref="ICommandCoordinator{TCommand, TCommandFactory}"/>
public sealed class CommandCoordinator<TCommand, TCommandFactory>
    : ICommandCoordinator<TCommand, TCommandFactory>
    where TCommand : ICommand
{
    private readonly TCommandFactory CommandFactory;
    private readonly ICommandHandler<TCommand> CommandHandler;

    /// <summary>Instantiates a <see cref="CommandCoordinator{TCommand, TCommandFactory}"/>, coordinating creation and handling of commands.</summary>
    /// <param name="commandFactory">Handles creation of commands.</param>
    /// <param name="commandHandler">Handles commands.</param>
    public CommandCoordinator(
        TCommandFactory commandFactory,
        ICommandHandler<TCommand> commandHandler)
    {
        CommandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        CommandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
    }

    void ICommandCoordinator<TCommand, TCommandFactory>.Handle(
        DCreateCommandThroughFactory<TCommandFactory, TCommand> commandCreationDelegate)
    {
        if (commandCreationDelegate is null)
        {
            throw new ArgumentNullException(nameof(commandCreationDelegate));
        }

        var command = commandCreationDelegate(CommandFactory);

        CommandHandler.Handle(command);
    }
}
