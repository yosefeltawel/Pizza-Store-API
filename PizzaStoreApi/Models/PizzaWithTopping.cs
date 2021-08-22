using System.Collections.Generic;

namespace PizzaStoreAPi.Models
{
    public class PizzaWithTopping
    {
        public int Id { get; set; }
        public List<int> ToppingList { get; set; } = new List<int>();
    }
}