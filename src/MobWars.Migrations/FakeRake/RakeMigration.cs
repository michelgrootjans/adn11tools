using System;
using System.Collections.Generic;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;
using System.Linq;

namespace MobWars.Migrations.FakeRake
{
    internal class RakeMigration
    {
        private readonly Dictionary<string, string> environments;
        private readonly string[] arguments;

        public RakeMigration(string[] arguments)
        {
            this.arguments = arguments;
            environments = new Dictionary<string, string>
                               {
                                   {"web",  "Server=.;initial catalog=MobWars_Web;Integrated Security=SSPI"},
                                   {"test", "Server=.;initial catalog=MobWars_Test;Integrated Security=SSPI"}
                               };
        }

        public MigrationRunner Runner
        {
            get { return GetRunnerFor(ConnectionString); }
        }

        private MigrationRunner GetRunnerFor(string connectionString)
        {
            var announcer = new BaseAnnouncer(Console.WriteLine);
            var processorOptions = new ProcessorOptions {PreviewOnly = false, Timeout = 2000};

            var processor = new SqlServer2008ProcessorFactory()
                .Create(connectionString, announcer, processorOptions);

            return new MigrationRunner(
                GetType().Assembly,
                new RunnerContext(announcer),
                processor);
        }

        private string ConnectionString
        {
            get{return environments[GetEnvironment()];}
        }

        private string GetEnvironment()
        {
            return arguments.Any(e => e == "test") 
                ? "test" 
                : "web";
        }
    }
}