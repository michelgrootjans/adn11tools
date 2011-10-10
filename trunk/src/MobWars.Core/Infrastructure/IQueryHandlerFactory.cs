namespace MobWars.Core.Infrastructure
{
    public interface IQueryHandlerFactory
    {
        TQueryHandler Create<TQueryHandler>() where TQueryHandler:IQueryHandler;
    }
}