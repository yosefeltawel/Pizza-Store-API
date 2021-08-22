using System.Collections.Generic;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public interface IPizzaRepository
    {
        public IEnumerable<Pizza> PizzaList { get; }
        public Pizza GetPizzaById(int id);
    }
}