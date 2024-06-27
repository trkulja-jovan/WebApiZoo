using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiZoo.Controllers;
using WebApiZoo.Repositories;

namespace WebApiZoo.Tests
{
    [TestClass]
    public class FoodControllerTests
    {
        private IZooRepository _repository;
        private FoodController _controller;

        [TestInitialize]
        public void Setup()
        {
            _repository = new ZooRepository();
            _controller = new FoodController(_repository);
        }

        [TestMethod]
        public void GetFoodCount_ShouldReturnInitialFoodCount()
        {
            int expectedFoodCount = 0;

            var result = _controller.GetFoodCount() as OkObjectResult;
            var actualFoodCount = (int) result.Value;

            Assert.AreEqual(expectedFoodCount, actualFoodCount);
        }

        [TestMethod]
        public void IncreaseFoodCount_ShouldIncreaseFoodCount()
        {
            int amount = 100;
            int expectedFoodCount = 100;

            _controller.IncreaseFoodCount(amount);
            var result = _controller.GetFoodCount() as OkObjectResult;
            var actualFoodStock = (int)result.Value;

            // Assert
            Assert.AreEqual(expectedFoodCount, actualFoodStock);
        }

        [TestMethod]
        public void FeedAnimals_ShouldDecreaseFoodCount()
        {
            // assuming 3 animals with food consumption of 10 each
            int expectedFoodCount = 70; 

            _repository.IncreaseFoodCount(expectedFoodCount);

            _controller.FeedAnimals();
            var result = _controller.GetFoodCount() as OkObjectResult;
            var actualFoodStock = (int)result.Value;

            // Assert
            Assert.AreEqual(expectedFoodCount, actualFoodStock);
        }
    }
}
