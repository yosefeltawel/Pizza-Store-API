using FluentMigrator;

namespace PizzaStore.Migration._100;

[Migration(5)]
public class _0005_PizzaToppingTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.PizzaTopping)
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().Indexed().NotNullable()
            .WithColumn("OrderPizzaId").AsInt32().ForeignKey(Tables.OrderPizza, "Id").NotNullable()
            .WithColumn("ToppingId").AsInt32().ForeignKey(Tables.Topping, "Id").NotNullable();
    }
}