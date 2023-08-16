using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Core.Models;
using PizzaStore.Core.Repositories;

namespace PizzaStore.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PizzaController : Controller
{
    private readonly IPizzaRepository _repository;

    public PizzaController(IPizzaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("pizzas")]
    public async Task<IEnumerable<PizzaModel>> GetAllPizzas()
    {
        var pizzas = await _repository.GetAllPizzasAsync();
        return pizzas;
    }
}