using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class RecipeFood : AuditableEntity
    {
        public int RecipeId { get; set; }

        public int FoodId { get; set; }

        public double Quantity { get; set; }

        public short MeasureUnitId { get; set; }

        public Recipe? Recipe { get; set; }

        public Food? Food { get; set; }

        public MeasureUnit? MeasureUnit { get; set; }
    }
}
