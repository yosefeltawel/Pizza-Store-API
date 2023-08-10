using FluentMigrator;

namespace PizzaStore.Migration.Seed;

[Migration(1001)]
public class _1001_SeedPizza : AutoReversingMigration
{
    #nullable enable
    private record Pizza(string Name, decimal Price, string Ingredients);
    #nullable disable

    public override void Up()
    {
        var pizzas = new Pizza[]
        {
            new("Hot & Spicy", 115, "Italian Sausage, Tomato, Onions, Green Pepper, Jalapeno"),
            new("Pepperoni", 130, "Pepperoni, Extra Mozzarella Cheese"),
            new("Chicken BBQ", 130, "Grilled Chicken, Onions, Fresh Mushroom, BBQ Sauce"),
            new("Chicken Ranch", 135, "Grilled Chicken, Tomato, Fresh Mushroom, Ranch Sauce"),
            new("Shrimps", 130, "Shrimps, Tomato, Onions, Green Pepper"),
            new("Margherita", 100, "Mozzarella Cheese and Pizza Sauce")
        };

        foreach (var pizza in pizzas)
        {
            Insert.IntoTable(Tables.Pizza).Row(new {pizza.Name, pizza.Price, pizza.Ingredients});
        }
    }
}