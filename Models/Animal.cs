namespace WebApiZoo.Models
{
    public class Animal
    {
        public int FoodConsumption { get; set; }
        public string? Characteristics { get; set; }
        public AnimalNutritionType AnimalNutritionType { get; set; }
        public string? Name { get; set; }
    }

    public enum AnimalNutritionType
    {
        Carnivore, Herbivore
    }
}
