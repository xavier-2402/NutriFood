namespace NutriFood.Domain.Entities
{
    public class MealPlan
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int AdequacyPercentageId { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short ModUsr { get; set; }

        public AdequacyPercentage AdequacyPercentage { get; set; }

        public ICollection<FoodMenu> FoodMenus { get; set; }
            = new HashSet<FoodMenu>();
    }
}
