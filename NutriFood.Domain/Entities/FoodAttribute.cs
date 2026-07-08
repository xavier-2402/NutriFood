namespace NutriFood.Domain.Entities
{
    public class FoodAttribute
    {
        public short Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public short MeasureUnitId { get; set; }

        public MeasureUnit? MeasureUnit { get; set; }

        public ICollection<FoodAttributeValue> FoodAttributeValues { get; set; }
            = new HashSet<FoodAttributeValue>();

        public ICollection<AdequacyAttributeValue> AdequacyAttributeValues { get; set; }
            = new HashSet<AdequacyAttributeValue>();
    }
}
