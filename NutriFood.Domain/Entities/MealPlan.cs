using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class MealPlan: AuditableEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int AdequacyPercentageId { get; set; }

        public AdequacyPercentage? AdequacyPercentage { get; set; }

        public ICollection<FoodMenu> FoodMenus { get; set; }
            = new HashSet<FoodMenu>();
    }
}
