using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStoreAPi.Models;
using PizzaStoreAPi.Repositories;

namespace PizzaStoreAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IPizzaRepository _repository;

        public PizzaController(ILogger<PizzaController> logger, IPizzaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return _repository.PizzaList;
        }
    }
}