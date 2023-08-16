using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PizzaStore.Core;
using PizzaStore.Core.Models;
using Spectre.Console;

namespace PizzaStore.Repositories;

public static class ToppingRepository
{
    public static void DisplayToppingTable(List<ToppingModel> toppings)
    {
        var toppingTable = new Table();

        toppingTable.AddColumn(new TableColumn("Topping Number"));
        toppingTable.AddColumn(new TableColumn("Name"));
        toppingTable.AddColumn(new TableColumn("Price"));

        foreach (var topping in toppings)
        {
            var rows = new List<Markup>
            {
                new(topping.Id.ToString()),
                new(topping.Name),
                new(topping.Price.ToString(Constants.PriceDisplay))
            };

            toppingTable.AddRow(rows);
        }

        AnsiConsole.Render(toppingTable);
    }

    public static async Task<List<ToppingModel>> GetToppingFromApi()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://localhost:5001/api/v1/Topping/toppings");
        var toppings = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<List<ToppingModel>>(toppings, options);

        return result;
    }
}