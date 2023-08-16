using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Core.Models;
using PizzaStore.Repositories;
using Spectre.Console;

namespace PizzaStore;

class Program
{
    static async Task Main()
    {
        AnsiConsole.WriteLine("Welcome to pizza store!");

        while (true)
        {
            var answer = AnsiConsole.Prompt(new TextPrompt<int>("Do you want to make a new order or check your old orders? 1 for new order, 2 for old orders, 0 to exit")
                .Validate(input =>
                {
                    return input switch
                    {
                        < 0 => ValidationResult.Error("[red]Invalid input[/]"),
                        > 2 => ValidationResult.Error("[red]Invalid input[/]"),
                        _ => ValidationResult.Success()
                    };
                })
            );

            var order = new OrderModel();

            switch (answer)
            {
                case 1:
                {
                    var pizzas = await PizzaRepository.GetPizzaFromApi();
                    var toppings = await ToppingRepository.GetToppingFromApi();
                    //Making an order
                    var index = 1;

                    while (true)
                    {
                        PizzaRepository.DisplayPizzaTable(pizzas);

                        var pizzaId = AnsiConsole.Prompt(new TextPrompt<int>("Please choose your pizza")
                            .Validate(pizzaId => pizzas.Where(x => x.Id == pizzaId).FirstOrDefault() == null
                                ? ValidationResult.Error("[red]Invalid input[/]")
                                : ValidationResult.Success()));

                        var pizzaWithToppings = new PizzaWithToppingsModel
                        {
                            Id = pizzas.Where(x => x.Id == pizzaId).FirstOrDefault().Id
                        };

                        order.TotalCost += pizzas.Where(x => x.Id == pizzaId).FirstOrDefault().Price;

                        while (true)
                        {
                            //Adding topping
                            var addTopping = AnsiConsole.Confirm("Do you want to add any topping on your pizza? y for [green]Yes[/], n for [red]No[/]");

                            if (addTopping)
                            {
                                ToppingRepository.DisplayToppingTable(toppings);

                                var chooseTopping = AnsiConsole.Prompt(new TextPrompt<int>("Please Choose your extra topping.")
                                    .Validate(toppingId => toppings.Where(x => x.Id == toppingId).FirstOrDefault() == null
                                        ? ValidationResult.Error("[red]Invalid input[/]")
                                        : ValidationResult.Success()));

                                pizzaWithToppings.ToppingList.Add(new ToppingModel {Id = chooseTopping, PizzaId = index});

                                order.TotalCost += toppings.Where(x => x.Id == chooseTopping).FirstOrDefault().Price;
                            }
                            else
                            {
                                break;
                            }
                        }

                        order.Pizzas.Add(pizzaWithToppings);
                        AnsiConsole.WriteLine($"Pizza count => {order.Pizzas.Count}");

                        if (AnsiConsole.Confirm("Do you want to add another pizza? y for [green]Yes[/] n for [red]No[/]"))
                        {
                            index++;
                            continue;
                        }

                        break;
                    }

                    var addNote = AnsiConsole.Confirm("Do you want to leave any notes to the chef? y for [green]Yes[/] n for [red]No[/]");

                    if (addNote)
                    {
                        var note = AnsiConsole.Prompt(new TextPrompt<string>("Leave your note here")
                            .Validate(input => input == null
                                ? ValidationResult.Error("[Orange]please leave your note here[/]")
                                : ValidationResult.Success()));

                        order.Note = note;
                    }

                    await OrderRepository.PostOrderToApi(order);
                    break;
                }

                case 2:
                {
                    //Viewing order list
                    var orders = await OrderRepository.GetOrdersFromApi();

                    if (orders.Count == 0)
                    {
                        AnsiConsole.WriteLine("You don't have any orders yet!");
                    }
                    else
                    {
                        foreach (var o in orders)
                            OrderRepository.DisplayOrderTable(o);
                    }

                    break;
                }

                case 0:
                {
                    //Good bye
                    AnsiConsole.WriteLine("Good Bye!");
                    break;
                }
            }

            break;
        }
    }
}