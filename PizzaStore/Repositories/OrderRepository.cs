using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PizzaStore.Core;
using PizzaStore.Core.Models;
using PizzaStore.Read.DtoClasses;
using Spectre.Console;

namespace PizzaStore.Repositories;

public static class OrderRepository
{
    public static void DisplayOrderTable(OrderView order)
    {
        var orderTable = new Table
        {
            Title = new TableTitle($"Order Number {order.Id.ToString()}"),
        };

        orderTable.AddColumn(new TableColumn("Pizza"));
        orderTable.AddColumn(new TableColumn("Price"));
        orderTable.AddColumn(new TableColumn("Topping"));
        orderTable.AddColumn(new TableColumn("Price"));

        foreach (var pizza in order.OrderPizzas)
        {
            var row = new List<Markup>
            {
                new(pizza.Pizza.Name),
                new(pizza.Pizza.Price.ToString(Constants.PriceDisplay))
            };

            var toppings = "";
            var prices = "";
            foreach (var topping in pizza.PizzaToppings)
            {
                prices += topping.Topping.Name;
                prices += topping.Topping.Price.ToString(Constants.PriceDisplay);

                if (pizza.PizzaToppings.IndexOf(topping) != pizza.PizzaToppings.Count - 1)
                {
                    prices += Environment.NewLine;
                    prices += Environment.NewLine;
                }
            }

            if (pizza.PizzaToppings.Count is 0)
            {
                toppings += "-";
                prices += "-";
            }

            row.Add(new Markup(toppings));
            row.Add(new Markup(prices));
            orderTable.AddRow(row);
        }

        var totalPrice = order.OrderPizzas.Sum(x => x.Pizza.Price) + order.OrderPizzas.Sum(x => x.PizzaToppings.Sum(t => t.Topping.Price));

        AnsiConsole.Render(orderTable);
        AnsiConsole.WriteLine($"Total Price: {totalPrice}");
    }

    public static async Task<List<OrderView>> GetOrdersFromApi()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://localhost:5001/api/v1/Order/get-orders");
        var order = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<List<OrderView>>(order, options);

        return result;
    }

    public static async Task PostOrderToApi(OrderModel order)
    {
        var client = new HttpClient();
        var content = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");
        await client.PostAsync("https://localhost:5001/api/v1/Order/add-order", content);
    }
}