using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PizzaStore.Core;
using PizzaStore.Core.Models;
using Spectre.Console;

namespace PizzaStore.Repositories;

public static class PizzaRepository
{
    public static void DisplayPizzaTable(IEnumerable<PizzaModel> pizzas)
    {
        var pizzaTable = new Table();

        pizzaTable.AddColumn(new TableColumn("Pizza Number"));
        pizzaTable.AddColumn(new TableColumn("Name"));
        pizzaTable.AddColumn(new TableColumn("Ingredients"));
        pizzaTable.AddColumn(new TableColumn("Price"));

        foreach (var pizza in pizzas)
        {
            var rows = new List<Markup>
            {
                new(pizza.Id.ToString()),
                new(pizza.Name),
                new(pizza.Ingredients),
                new(pizza.Price.ToString(Constants.PriceDisplay))
            };

            pizzaTable.AddRow(rows);
        }

        AnsiConsole.Render(pizzaTable);
    }

    public static async Task<List<PizzaModel>> GetPizzaFromApi()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://localhost:5001/api/v1/Pizza/pizzas");
        var pizzas = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var result = JsonSerializer.Deserialize<List<PizzaModel>>(pizzas, options);

        return result;
    }
}