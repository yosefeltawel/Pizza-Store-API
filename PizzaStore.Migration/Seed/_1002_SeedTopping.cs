using FluentMigrator;

namespace PizzaStore.Migration.Seed;

[Migration(1002)]
public class _1002_SeedTopping : AutoReversingMigration
{
    #nullable enable
    private record Topping(string Name, decimal Price);
    #nullable disable

    public override void Up()
    {
        var toppings = new Topping[]
        {
            new("Cheddar", 15),
            new("Pepperoni", 30),
            new("Sausage", 25),
            new("Ranch Sauce", 17)
        };

        foreach (var topping in toppings)
        {
            Insert.IntoTable(Tables.Topping).Row(new {topping.Name, topping.Price});
        }
    }
}