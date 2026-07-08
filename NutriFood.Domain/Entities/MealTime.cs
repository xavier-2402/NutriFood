namespace NutriFood.Domain.Entities
{
    public class MealTime
    {
        public short Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public ICollection<FoodMenu> FoodMenus { get; set; }
            = new HashSet<FoodMenu>();
    }
}
