using WebApiZoo.Models;

namespace WebApiZoo.Repositories
{
    public class ZooRepository : IZooRepository
    {
        private Zoo _zoo;

        public ZooRepository()
        {
            _zoo = new();
        }

        public void AddAnimal(Animal animal) => _zoo.AddAnimal(animal);

        public List<Animal> GetAllAnimals() => _zoo.GetAllAnimals();

        public void FeedAnimals()
        {
            _zoo.FeedAnimals();
        }

        public void IncreaseFoodCount(int amount)
        {
            _zoo.IncreaseFoodCount(amount);
        }

        public List<Animal> GetAnimalsByNutritionType(int nutritionType)
        {
            return _zoo.GetAnimalsByNutritionType(nutritionType);
        }

        public int? GetFoodCount() => _zoo.GetFoodCount();

        public void AutoFeedAnimals()
        {
            _zoo.AutoFeedAnimals();
        }

        public void SimulateFoodSupply(int foodAmount)
        {
            _zoo.SimulateFoodSupply(foodAmount);
        }

        public void SimulateHunger(double hungerIncreaseFactor)
        {
            _zoo.SimulateHunger(hungerIncreaseFactor);
        }
    }
}
