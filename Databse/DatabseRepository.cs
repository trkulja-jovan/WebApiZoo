using WebApiZoo.Models;
using WebApiZoo.Repositories;

namespace WebApiZoo.Databse
{
    public class DatabseRepository : IZooRepository
    {
        private ZooDbContext _zooDbContext;

        public DatabseRepository(ZooDbContext zooDbContext)
        {
            _zooDbContext = zooDbContext;   
        }

        public void AddAnimal(Animal animal)
        {
            _zooDbContext.Animals.Add(animal);
            _zooDbContext.SaveChanges();
        }

        public void AutoFeedAnimals()
        {
            //ovo ne treba ovde
        }

        public void FeedAnimals()
        {
            //ovo je samo test primer
            var animals = _zooDbContext.Animals.ToList();
            var foodCount = _zooDbContext.Foods.FirstOrDefault();
            if (foodCount != null)
            {
                foreach (var animal in animals)
                {
                    int foodConsumption = animal.FoodConsumption;

                    if (animal.AnimalNutritionType == AnimalNutritionType.Carnivore)
                    {
                        foodConsumption *= 3;
                    }
                    else if (animal.AnimalNutritionType == AnimalNutritionType.Herbivore && animal.Characteristics != "Zirafa")
                    {
                        foodConsumption /= 2;
                    }

                    foodCount.FoodAmount -= foodConsumption;
                }
                _zooDbContext.SaveChanges();
            }
        }

        public List<Animal> GetAllAnimals()
        {
            return [.. _zooDbContext.Animals];
        }

        public List<Animal> GetAnimalsByNutritionType(int nutritionType)
        {
            return _zooDbContext.Animals.Where(a => (int)a.AnimalNutritionType == nutritionType).ToList();
        }

        public int? GetFoodCount()
        {
            return _zooDbContext.Foods?.Sum(food => food.FoodAmount);
        }

        public void IncreaseFoodCount(int foodCount)
        {
            //pravilno bi bilo da se po ID pretrazuje i povecava food count, ili po name-u ali posto sam ogranicen
            //vremenom uradicu samo za prvi element
            var foodAmount = _zooDbContext.Foods.FirstOrDefault();
            if (foodAmount != null)
            {
                foodAmount.FoodAmount += foodCount;
            }
            else
            {
                _zooDbContext.Foods.Add(new Food { FoodAmount = foodCount, Name = "food name" });
            }

            _zooDbContext.SaveChanges();
        }

        public void SimulateFoodSupply(int foodAmount)
        {
            //ovo ne treba ovde, ali da bih izbegao kreiranje novog repo zato stoji
        }

        public void SimulateHunger(double hungerIncreaseFactor)
        {
            //ovo ne treba ovde, ali da bih izbegao kreiranje novog repo zato stoji
        }
    }
}
