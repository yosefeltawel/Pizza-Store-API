namespace PizzaStore.Core.Models;

public class PizzaModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public string? Ingredients { get; set; }
}