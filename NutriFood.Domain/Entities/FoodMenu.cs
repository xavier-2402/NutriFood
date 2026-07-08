namespace NutriFood.Domain.Entities
{
    public class FoodMenu
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int MealPlanId { get; set; }

        public short? MealTimeId { get; set; }

        public bool Active { get; set; } = true;

        public short? CreaUsr { get; set; }

        public DateTime CreaDate { get; set; }

        public short? ModUsr { get; set; }

        public DateTime ModDate { get; set; }

        public MealPlan? MealPlan { get; set; }

        public MealTime? MealTime { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
            = new HashSet<Recipe>();
    }
}
