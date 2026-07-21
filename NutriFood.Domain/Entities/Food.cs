using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class Food : AuditableEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public short FoodCategoryId { get; set; }

        public short FoodClassificationId { get; set; }

        public string? ImageUrl { get; set; }

        public FoodCategory? FoodCategory { get; set; }

        public FoodClassification? FoodClassification { get; set; }

        public ICollection<FoodAttributeValue> FoodAttributeValues { get; set; }
            = new HashSet<FoodAttributeValue>();

        public ICollection<RecipeFood> RecipeFoods { get; set; }
            = new HashSet<RecipeFood>();
    }
}
