using System.Collections.Generic;
using System.Linq;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        public PizzaRepository()
        {
            PizzaList = JsonManager.ReadJsonFile<IEnumerable<Pizza>>(@"./Data/pizza.json");
        }
        public IEnumerable<Pizza> PizzaList { get; set; }

        public Pizza GetPizzaById(int id)
        {
            return PizzaList.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}