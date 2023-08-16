using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Core.Repositories;

namespace PizzaStore.API;

public static class ServiceRegistrations
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<IPizzaRepository, PizzaRepository>();
        services.AddTransient<IToppingRepository, ToppingRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
    }
}