using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class FoodAttribute : IEntity<short>, ICodeEntity, IActivableEntity
    {
        public short Id { get; set; }


        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public short MeasureUnitId { get; set; }

        public bool Active { get; set; } = true;

        public MeasureUnit? MeasureUnit { get; set; }

        public List<FoodAttributeValue> FoodAttributeValues { get; set; } = [];
        public List<RecipeFoodAttributeValue> RecipeFoodAttributeValues { get; set; } = [];
        public List<AdequacyAttributeValue> AdequacyAttributeValues { get; set; } = [];
    }
}
