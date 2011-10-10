using FluentMigrator.Runner;

namespace MobWars.Migrations.FakeRake
{
    internal class MigrateDownRakeCommand : IRakeCommand
    {
        private readonly MigrationRunner runner;

        public MigrateDownRakeCommand(string[] arguments)
        {
            runner = new RakeMigration(arguments).Runner;
        }

        public void Execute()
        {
            runner.RollbackToVersion(0);
        }
    }
}