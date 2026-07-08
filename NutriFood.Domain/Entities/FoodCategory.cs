namespace NutriFood.Domain.Entities
{
    public class FoodCategory
    {
        public short Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public ICollection<Food> Foods { get; set; }
            = new HashSet<Food>();
    }
}
