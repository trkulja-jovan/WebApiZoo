using Microsoft.AspNetCore.Mvc;
using WebApiZoo.Repositories;

namespace WebApiZoo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private IZooRepository _repository;
        public FoodController(IZooRepository zooRepository)
        {
            _repository = zooRepository;
        }

        [HttpGet("foodcount")]
        public IActionResult GetFoodCount()
        {
            var foodCount = _repository.GetFoodCount();
            return Ok(foodCount);
        }

        [HttpPost("purchase")]
        public IActionResult IncreaseFoodCount(int amount)
        {
            _repository.IncreaseFoodCount(amount);
            return Ok();
        }

        [HttpPost("feed")]
        public IActionResult FeedAnimals()
        {
            _repository.FeedAnimals();
            return Ok();
        }

        [HttpPost("auto-feed")]
        public IActionResult AutoFeedAnimals()
        {
            _repository.AutoFeedAnimals();
            return Ok();
        }

        [HttpPost("simulate-supply")]
        public IActionResult SimulateRegularFoodSupply(int foodAmount)
        {
            _repository.SimulateFoodSupply(foodAmount);
            return Ok();
        }
    }
}
