namespace NutriFood.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;    

        public string? Description { get; set; }

        public int FoodMenuId { get; set; }

        public bool Active { get; set; } = true;

        public short? CreaUsr { get; set; }

        public DateTime CreaDate { get; set; }

        public short? ModUsr { get; set; }

        public DateTime ModDate { get; set; }

        public FoodMenu? FoodMenu { get; set; }

        public ICollection<RecipeFood> RecipeFoods { get; set; }
            = new HashSet<RecipeFood>();
    }
}
