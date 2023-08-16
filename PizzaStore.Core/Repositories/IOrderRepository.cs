using System.Data;
using PizzaStore.Core.Models;
using PizzaStore.Data.DatabaseSpecific;
using PizzaStore.Read.DtoClasses;
using PizzaStore.Read.Persistence;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Serilog;

namespace PizzaStore.Core.Repositories;

public interface IOrderRepository
{
    Task<bool> AddOrder(OrderModel input);

    Task<List<OrderView>> GetAllOrdersAsync();
}

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(DataAccessAdapter adapter) : base(adapter)
    {
    }

    public async Task<bool> AddOrder(OrderModel input)
    {
        try
        {
            await _adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, nameof(AddOrder));

            var e = input.ToEntity();

            await _adapter.SaveEntityAsync(e, true);

            foreach (var pizza in input.Pizzas)
            {
                var pizzaEntity = input.ToOrderPizzaEntity(e.Id, pizza.Id);

                await _adapter.SaveEntityAsync(pizzaEntity, true);

                foreach (var topping in pizza.ToppingList!)
                {
                    var toppingEntity = input.ToPizzaToppingEntity(pizzaEntity.Id, topping.Id);

                    await _adapter.SaveEntityAsync(toppingEntity);
                }
            }

            await _adapter.CommitAsync(CancellationToken.None);

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, string.Empty);
            _adapter.Rollback();
            return false;
        }
    }

    public async Task<List<OrderView>> GetAllOrdersAsync()
    {
        try
        {
            var orderList = await _meta.Order.ProjectToOrderView().ToListAsync();
            return orderList;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}