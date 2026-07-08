namespace NutriFood.Domain.Entities
{
    public class AdequacyAttributeValue
    {
        public int AdequacyPercentageId { get; set; }

        public short AttributeId { get; set; }

        public double Percentage { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short? CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short? ModUsr { get; set; }

        public AdequacyPercentage? AdequacyPercentage { get; set; }

        public FoodAttribute? Attribute { get; set; }
    }
}
