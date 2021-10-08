using FluentMigrator;

namespace Schema
{
    [Migration(5)]
    public class _0005_OrderPizzaWithTopping : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("PizzaWithTopping")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().Indexed().NotNullable()
                .WithColumn("OrderPizzaId").AsInt32().NotNullable()
                .ForeignKey("fk_PizzaWithTopping_Id", "OrderPizza", "Id").Indexed()
                .WithColumn("ToppingId").AsInt32().NotNullable()
                .ForeignKey("fk_Topping_PizzaWithTopping", "Topping", "Id").Indexed();
        }
    }
}