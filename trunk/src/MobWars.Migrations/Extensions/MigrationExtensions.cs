using FluentMigrator.Builders.Create;
using FluentMigrator.Builders.Create.Table;

namespace MobWars.Migrations.Extensions
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax DefaultTable(this ICreateExpressionRoot create, string tableName)
        {
            return create.Table(tableName)
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().WithDefaultValue("newid()");
        }
    }
}