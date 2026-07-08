namespace NutriFood.Domain.Entities
{
    public class FoodAttributeValue
    {
        public int FoodId { get; set; }

        public short AttributeId { get; set; }

        public double Value { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short? CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short? ModUsr { get; set; }

        public Food? Food { get; set; }

        public FoodAttribute? Attribute { get; set; }
    }
}
