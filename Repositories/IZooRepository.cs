using WebApiZoo.Models;

namespace WebApiZoo.Repositories
{
    public interface IZooRepository
    {
        List<Animal> GetAnimalsByNutritionType(int nutritionType);
        void IncreaseFoodCount(int foodCount);
        void FeedAnimals();
        List<Animal> GetAllAnimals();
        void AddAnimal(Animal animal);
        int GetFoodCount();
    }
}
