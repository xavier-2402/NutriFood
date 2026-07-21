using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class Recipe : AuditableEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;    

        public string? Description { get; set; }

        public int FoodMenuId { get; set; }

        public FoodMenu? FoodMenu { get; set; }

        public ICollection<RecipeFood> RecipeFoods { get; set; }
            = new HashSet<RecipeFood>();
    }
}
