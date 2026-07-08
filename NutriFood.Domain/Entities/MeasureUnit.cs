namespace NutriFood.Domain.Entities
{
    public class MeasureUnit
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;    

        public string Abbreviation { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public ICollection<FoodAttribute> FoodAttributes { get; set; }
            = new HashSet<FoodAttribute>();

        public ICollection<RecipeFood> RecipeFoods { get; set; }
            = new HashSet<RecipeFood>();
    }
}
