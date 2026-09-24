using NutriFood.Domain.Common.Base;
using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class Food : AuditableEntity, IEntity<int>, ICodeEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public short FoodCategoryId { get; set; }

        public short? FoodClassificationId { get; set; }

        public string? ImageUrl { get; set; }

        public FoodCategory? FoodCategory { get; set; }

        public FoodClassification? FoodClassification { get; set; }

        public List<FoodAttributeValue> FoodAttributeValues { get; set; } = [];

        public List<RecipeFood> RecipeFoods { get; set; } = [];
    }
}
