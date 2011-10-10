using FluentMigrator;
using MobWars.Migrations.Extensions;

namespace MobWars.Migrations.Migrations
{
    [Migration(002)]
    public class M002_Items : Migration
    {
        private const string ForeignKeyColumn = "OwnerId";
        private const string ForeignKeyName = "FK_Item_Owner";
        public const string TableName = "Items";

        public override void Up()
        {
            Create.DefaultTable(TableName)
                .WithColumn(ForeignKeyColumn).AsGuid().Nullable() //an item doesn't NEED to be owned
                .WithColumn("discriminator").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Price").AsInt32().NotNullable().WithDefaultValue(0);

            Create.ForeignKey(ForeignKeyName)
                .FromTable(TableName)
                .ForeignColumn(ForeignKeyColumn)
                .ToTable(M001_Character.TableName)
                .PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}