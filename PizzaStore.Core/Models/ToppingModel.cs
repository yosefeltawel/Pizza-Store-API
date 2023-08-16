namespace PizzaStore.Core.Models;

public class ToppingModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Price { get; set; }

    public int? PizzaId { get; set; }
}