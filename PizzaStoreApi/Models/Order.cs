using System.Collections.Generic;

namespace PizzaStoreAPi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<PizzaWithTopping> Pizzas { get; set; } = new List<PizzaWithTopping>();
        public decimal TotalCost { get; set; }
    }
}