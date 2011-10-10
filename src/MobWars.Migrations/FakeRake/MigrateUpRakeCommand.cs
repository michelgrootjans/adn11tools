using System.Collections.Generic;
using FluentMigrator.Runner;

namespace MobWars.Migrations.FakeRake
{
    internal class MigrateUpRakeCommand : IRakeCommand
    {
        private readonly MigrationRunner runner;
        private readonly long targetVersion;
        private readonly long actualVersion;

        public MigrateUpRakeCommand(string[] arguments)
        {
            runner = new RakeMigration(arguments).Runner;
            targetVersion = GetTargetVersion(arguments);
            actualVersion = GetActualVersion();
        }

        public void Execute()
        {
            if (targetVersion == -1)
                runner.MigrateUp();
            else if (targetVersion > actualVersion)
                runner.MigrateUp(targetVersion);
            else
                runner.RollbackToVersion(targetVersion);
        }

        private long GetActualVersion()
        {
            return runner.VersionLoader.VersionInfo.Latest();
        }

        private static long GetTargetVersion(IEnumerable<string> arguments)
        {
            foreach (var argument in arguments)
            {
                long v;
                if (long.TryParse(argument, out v))
                    return v;
            }
            return -1;
        }
    }
}