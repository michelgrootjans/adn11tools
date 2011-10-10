using System;
using System.Collections.Generic;

namespace MobWars.Migrations.FakeRake
{
    public class Rake
    {
        private readonly IDictionary<string, Func<string[], IRakeCommand>> commands;

        public Rake()
        {
            commands = new Dictionary<string, Func<string[], IRakeCommand>>
                           {
                               {"db:migrate", args => new MigrateUpRakeCommand(args)},
                               {"db:reset", args => new MigrateDownRakeCommand(args)},
                               {"db:seed", args => new SeedDatabaseRakeCommand()}
                           };
        }

        public void Execute(params string[] args)
        {
            try
            {
                FindCommand(args).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                PrintUsage();
            }
        }

        private void PrintUsage()
        {
            Console.WriteLine("Available commands for Rake:");
            foreach (var command in commands)
            {
                Console.WriteLine("- {0}", command.Key);
            }
        }

        private IRakeCommand FindCommand(string[] args)
        {
            return commands[args[0]].Invoke(args);
        }
    }
}