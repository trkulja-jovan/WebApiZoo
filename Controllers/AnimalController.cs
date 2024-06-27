using Microsoft.AspNetCore.Mvc;
using WebApiZoo.Models;
using WebApiZoo.Repositories;

namespace WebApiZoo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private IZooRepository _repository;

        public AnimalController(IZooRepository zooRepository)
        {
            _repository = zooRepository;
        }

        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            var animals = _repository.GetAllAnimals();
            return Ok(animals);
        }

        [HttpGet("{nutritionType}")]
        public IActionResult GetAnimalsBySpecies(int nutritionType)
        {
            var animals = _repository.GetAnimalsByNutritionType(nutritionType);
            return Ok(animals);
        }
    }
}
