using FluentMigrator;

namespace PizzaStore.Migration._100;

[Migration(2)]
public class _0002_ToppingTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Topping)
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(250).NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable();
    }
}