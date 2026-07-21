using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class AdequacyPercentage :AuditableEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int PatientId { get; set; }

        public Patient? Patient { get; set; }

        public ICollection<AdequacyAttributeValue> AdequacyAttributeValues { get; set; }
            = new HashSet<AdequacyAttributeValue>();

        public ICollection<MealPlan> MealPlans { get; set; }
            = new HashSet<MealPlan>();
    }
}
