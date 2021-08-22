using System.Collections.Generic;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public interface IToppingRepository
    {
        public IEnumerable<Topping> ToppingList { get; set; }
        public Topping GetToppingById(int id);
    }
}