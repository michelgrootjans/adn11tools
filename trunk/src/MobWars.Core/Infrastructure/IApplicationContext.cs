namespace MobWars.Core.Infrastructure
{
    public interface IApplicationContext
    {
        string CurrentUserName { get; }
    }
}