using NutriFood.Domain.Common.Base;
using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class Recipe : AuditableEntity, IEntity<int>, ICodeEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;    

        public string? Description { get; set; }

        public int FoodMenuId { get; set; }

        public FoodMenu? FoodMenu { get; set; }

        public List<RecipeFood> RecipeFoods { get; set; } = [];
    }
}
