using System.Collections.Generic;
using System.Linq;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        public ToppingRepository()
        {
            ToppingList = JsonManager.ReadJsonFile<IEnumerable<Topping>>(@"./Data/toppings.json");
        }

        public IEnumerable<Topping> ToppingList { get; set; }
        
        public Topping GetToppingById(int id)
        {
            return ToppingList.Where(t => t.Id == id).FirstOrDefault();
        }

        
    }
}