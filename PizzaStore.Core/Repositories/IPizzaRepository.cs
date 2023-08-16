using Mapster;
using PizzaStore.Core.Models;
using PizzaStore.Data.DatabaseSpecific;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Serilog;

namespace PizzaStore.Core.Repositories;

public interface IPizzaRepository
{
    Task<List<PizzaModel>> GetAllPizzasAsync();
}

public class PizzaRepository : BaseRepository, IPizzaRepository
{
    public PizzaRepository(DataAccessAdapter adapter) : base(adapter)
    {
    }

    public async Task<List<PizzaModel>> GetAllPizzasAsync()
    {
        try
        {
            var pizzas = await _meta.Pizza.ToListAsync();
            return pizzas.ConvertAll(p => p.Adapt<PizzaModel>());
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new List<PizzaModel>();
        }
    }
}