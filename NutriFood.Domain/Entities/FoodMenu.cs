using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class FoodMenu: AuditableEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int MealPlanId { get; set; }

        public short? MealTimeId { get; set; }

        public MealPlan? MealPlan { get; set; }

        public MealTime? MealTime { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
            = new HashSet<Recipe>();
    }
}
