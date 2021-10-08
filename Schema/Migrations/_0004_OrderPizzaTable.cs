using FluentMigrator;
using FluentMigrator.Postgres;

namespace Schema
{
    [Migration(4)]
    public class _0004_OrderPizzaTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("OrderPizza")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity().Indexed()
                .WithColumn("OrderId").AsInt32().NotNullable().ForeignKey("fk_Order_OrderPizza_Id", "Order", "Id").Indexed()
                .WithColumn("PizzaId").AsInt32().NotNullable().ForeignKey("fk_Pizza_OrderPizza_Id", "Pizza", "Id").Indexed();
        }
    }
}