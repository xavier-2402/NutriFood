using NutriFood.Domain.Common.Base;
using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class AdequacyPercentage : AuditableEntity, IEntity<int>, ICodeEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int PatientId { get; set; }

        public Patient? Patient { get; set; }

        public List<AdequacyAttributeValue> AdequacyAttributeValues { get; set; } = [];

        public List<MealPlan> MealPlans { get; set; } = [];
    }
}
