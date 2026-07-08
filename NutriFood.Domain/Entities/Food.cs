namespace NutriFood.Domain.Entities
{
    public class Food
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public short FoodCategoryId { get; set; }

        public short FoodClassificationId { get; set; }

        public string? ImageUrl { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short? CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short? ModUsr { get; set; }

        public FoodCategory? FoodCategory { get; set; }

        public FoodClassification? FoodClassification { get; set; }

        public ICollection<FoodAttributeValue> FoodAttributeValues { get; set; }
            = new HashSet<FoodAttributeValue>();

        public ICollection<RecipeFood> RecipeFoods { get; set; }
            = new HashSet<RecipeFood>();
    }
}
