using FluentMigrator;

namespace PizzaStore.Migration._100;

[Migration(1)]
public class _0001_PizzaTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Pizza)
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(250).NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("Ingredients").AsString(250).NotNullable();
    }
}