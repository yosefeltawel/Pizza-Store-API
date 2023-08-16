using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStore.Core.Models;
using PizzaStore.Core.Repositories;
using Serilog;

namespace PizzaStore.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderRepository _repository;

    public OrderController(ILogger<OrderController> logger, IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("get-orders")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllOrders()
    {
        try
        {
            var orders = await _repository.GetAllOrdersAsync();

            return Ok(orders);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("add-order")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddOrder(OrderModel order)
    {
        try
        {
           var result = await _repository.AddOrder(order);

            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}