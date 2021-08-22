using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStoreAPi.Models;
using PizzaStoreAPi.Repositories;

namespace PizzaStoreAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToppingController : Controller
    {
        private readonly ILogger<ToppingController> _logger;
        private readonly IToppingRepository _repository;
        
        public ToppingController(ILogger<ToppingController> logger, IToppingRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Topping> Get()
        {
            return _repository.ToppingList;
        }
    }
}