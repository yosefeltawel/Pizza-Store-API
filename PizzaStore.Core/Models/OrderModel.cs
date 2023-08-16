using PizzaStore.Data.EntityClasses;

namespace PizzaStore.Core.Models;

public class OrderModel
{
    public List<PizzaWithToppingsModel> Pizzas { get; set; } = new();

    public decimal TotalCost { get; set; }

    public string? Note { get; set; }

    public OrderEntity ToEntity()
    {
        return new OrderEntity
        {
            Note = Note,
            IsNew = true
        };
    }

    public OrderPizzaEntity ToOrderPizzaEntity(int orderId, int pizzaId)
    {
        return new OrderPizzaEntity
        {
            OrderId = orderId,
            PizzaId = pizzaId,
            IsNew = true
        };
    }

    public PizzaToppingEntity ToPizzaToppingEntity(int orderPizzaId, int toppingId)
    {
        return new PizzaToppingEntity
        {
            OrderPizzaId = orderPizzaId,
            ToppingId = toppingId,
            IsNew = true
        };
    }
}