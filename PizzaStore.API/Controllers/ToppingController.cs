using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Core.Models;
using PizzaStore.Core.Repositories;

namespace PizzaStore.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ToppingController : Controller
{
    private readonly IToppingRepository _repository;

    public ToppingController(IToppingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("toppings")]
    public async Task<List<ToppingModel>> GetAllToppings()
    {
        try
        {
            var toppings = await _repository.GetAllToppingsAsync();
            return toppings;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}