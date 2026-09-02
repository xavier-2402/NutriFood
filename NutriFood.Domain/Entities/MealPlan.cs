using NutriFood.Domain.Common.Base;
using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class MealPlan : AuditableEntity, IEntity<int>, ICodeEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int AdequacyPercentageId { get; set; }

        public AdequacyPercentage? AdequacyPercentage { get; set; }

        public List<FoodMenu> FoodMenus { get; set; } = [];
    }
}
