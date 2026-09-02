using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class MeasureUnit : IEntity<short>, ICodeEntity, IActivableEntity
    {
        public short Id { get; set; }

        public string Name { get; set; } = string.Empty;    

        public string Abbreviation { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public string Code { get; set; } = string.Empty;

        public List<FoodAttribute> FoodAttributes { get; set; } = [];

        public List<RecipeFood> RecipeFoods { get; set; } = [];
    }
}
