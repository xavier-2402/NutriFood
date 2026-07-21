using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities
{
    public class FoodAttributeValue :AuditableEntity
    {
        public int FoodId { get; set; }

        public short AttributeId { get; set; }

        public double Value { get; set; }

        public Food? Food { get; set; }

        public FoodAttribute? Attribute { get; set; }
    }
}
