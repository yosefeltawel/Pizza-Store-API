namespace PizzaStore.Core.Models;

public class PizzaWithToppingsModel
{
    public int Id { get; set; }

    public List<ToppingModel>? ToppingList { get; set; } = new();
}