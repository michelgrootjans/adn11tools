using System;
using MobWars.Migrations.FakeRake;

namespace MobWars.Migrations
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var rake = new Rake();
                rake.Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}