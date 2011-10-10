namespace MobWars.Core.Infrastructure
{
    public interface ICommand
    {
    }

    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerFactory factory;

        public CommandDispatcher(ICommandHandlerFactory factory)
        {
            this.factory = factory;
        }

        public void Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = factory.CreateHandler<TCommand>();
            handler.Handle(command);
        }
    }

    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> CreateHandler<TCommand>() where TCommand : ICommand;
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}