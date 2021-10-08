using FluentMigrator;
using FluentMigrator.Builders.Schema.Table;

namespace Schema
{
    [Migration(1)]
    public class _0001_PizzaTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Pizza")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable().Indexed()
                .WithColumn("Name").AsString(30).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("Ingredients").AsString(200).NotNullable();
        }
    }
}