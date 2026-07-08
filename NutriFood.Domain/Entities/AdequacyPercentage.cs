namespace NutriFood.Domain.Entities
{
    public class AdequacyPercentage
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int PatientId { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short? CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short? ModUsr { get; set; }

        public Patient? Patient { get; set; }

        public ICollection<AdequacyAttributeValue> AdequacyAttributeValues { get; set; }
            = new HashSet<AdequacyAttributeValue>();

        public ICollection<MealPlan> MealPlans { get; set; }
            = new HashSet<MealPlan>();
    }
}
