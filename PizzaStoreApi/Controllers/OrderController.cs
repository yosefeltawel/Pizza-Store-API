using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStoreAPi.Models;
using PizzaStoreAPi.Repositories;

namespace PizzaStoreAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _repository;

        public OrderController(ILogger<OrderController> logger, IOrderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _repository.OrderList;
        }
        
        [HttpPost]
        public ActionResult<IEnumerable<Order>> Post(Order order)
        {
            try
            {
                _repository.AddOrder(order);
                _repository.SaveOrders();
                return StatusCode(StatusCodes.Status200OK, "Succeeded");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed");
            }
        }
    }
}