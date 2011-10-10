using System;
using FluentMigrator;
using MobWars.Migrations.Extensions;

namespace MobWars.Migrations.Migrations
{
    [Migration(001)]
    public class M001_Character : Migration
    {
        public const String TableName = "Characters";
    
        public override void Up()
        {
            Create.DefaultTable(TableName)
                .WithColumn("discriminator").AsString().NotNullable().Indexed()
                .WithColumn("username").AsString().Nullable().Indexed()
                .WithColumn("password").AsString().Nullable()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("experience").AsInt32().Nullable()
                .WithColumn("level").AsInt32().NotNullable()
                .WithColumn("hitpoints").AsInt32().NotNullable()
                .WithColumn("maxhitpoints").AsInt32().NotNullable()
                .WithColumn("attack").AsInt32().NotNullable()
                .WithColumn("defence").AsInt32().NotNullable()
                .WithColumn("gold").AsInt32().NotNullable()
                .WithColumn("adversary").AsGuid().Nullable().ForeignKey()
                ;

            Create.ForeignKey()
                .FromTable(TableName)
                .ForeignColumn("adversary")
                .ToTable(TableName)
                .PrimaryColumn("id");

        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}