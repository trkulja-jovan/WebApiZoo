using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace WebApiZoo.Models
{
    public class Zoo
    {
        private List<Animal> _animals;
        private int foodCount;

        public Zoo()
        {
            _animals = [];
            foodCount = 0;
        }

        public int GetFoodCount() => foodCount;

        public void IncreaseFoodCount(int amount) => foodCount += amount;
        public void DecreaseFoodCount(int amount) => foodCount -= amount;

        public void AddAnimal(Animal animal) => _animals.Add(animal);

        public List<Animal> GetAllAnimals() => _animals;

        public List<Animal> GetAnimalsByName(string name) => _animals.Where(a => a.Name == name).ToList();

        public List<Animal> GetAnimalsByNutritionType(int nutritionType) => _animals.Where(a => (int)a.AnimalNutritionType == nutritionType).ToList();

        public void FeedAnimals()
        {
            foreach (var animal in _animals)
            {
                int foodConsumption = animal.FoodConsumption;

                switch (animal.AnimalNutritionType)
                {
                    case AnimalNutritionType.Carnivore:
                        foodConsumption *= 3;
                        break;
                }

                if (animal.AnimalNutritionType == AnimalNutritionType.Herbivore && animal.Name != "Zirafa")
                    foodConsumption /= 2;

                DecreaseFoodCount(foodConsumption);
            }
        }

        public void AutoFeedAnimals()
        {
            if (foodCount > 0)
            {
                FeedAnimals();
            }
        }

        public void SimulateBirthAndDeath(double birthProbability, double deathProbability)
        {
            Random random = new();

            foreach (var animal in _animals)
            {
                if (random.NextDouble() < birthProbability)
                {
                    var newAnimal = new Animal 
                    { 
                        Name = animal.Name, 
                        Characteristics = animal.Characteristics, 
                        FoodConsumption = animal.FoodConsumption,
                        AnimalNutritionType = animal.AnimalNutritionType
                    };

                    AddAnimal(newAnimal);
                }

                if (random.NextDouble() < deathProbability)
                {
                    _animals.Remove(animal);
                }
            }
        }

        public void SimulateFoodSupply(int foodAmount)
        {
            IncreaseFoodCount(foodAmount);
        }

        public void SimulateHunger(double hungerIncreaseFactor)
        {
            foreach (var animal in _animals)
            {
                animal.FoodConsumption = (int)(animal.FoodConsumption * hungerIncreaseFactor);
            }
        }
    }
}
