using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class AdequacyAttributeValue : AuditableEntity
    {
        public int AdequacyPercentageId { get; set; }

        public short AttributeId { get; set; }

        public double Percentage { get; set; }

        public AdequacyPercentage? AdequacyPercentage { get; set; }

        public FoodAttribute? Attribute { get; set; }
    }
}
