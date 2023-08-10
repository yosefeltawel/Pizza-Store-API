using FluentMigrator;

namespace PizzaStore.Migration._100;

[Migration(4)]
public class _0004_OrderPizzaTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.OrderPizza)
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("OrderId").AsInt32().ForeignKey(Tables.Order, "Id").NotNullable()
            .WithColumn("PizzaId").AsInt32().ForeignKey(Tables.Pizza, "Id").NotNullable();
    }
}