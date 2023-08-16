using Mapster;
using PizzaStore.Core.Models;
using PizzaStore.Data.DatabaseSpecific;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Serilog;

namespace PizzaStore.Core.Repositories;

public interface IToppingRepository
{
    Task<List<ToppingModel>> GetAllToppingsAsync();
}

public class ToppingRepository : BaseRepository, IToppingRepository
{
    public ToppingRepository(DataAccessAdapter adapter) : base(adapter)
    {
    }

    public async Task<List<ToppingModel>> GetAllToppingsAsync()
    {
        try
        {
            var toppings = await _meta.Topping.ToListAsync();

            return toppings.ConvertAll(t => t.Adapt<ToppingModel>());
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new List<ToppingModel>();
        }
    }
}