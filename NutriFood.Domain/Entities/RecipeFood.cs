namespace NutriFood.Domain.Entities
{
    public class RecipeFood
    {
        public int RecipeId { get; set; }

        public int FoodId { get; set; }

        public double Quantity { get; set; }

        public short MeasureUnitId { get; set; }

        public bool Active { get; set; } = true;

        public short? CreaUsr { get; set; }

        public DateTime CreaDate { get; set; }

        public short? ModUsr { get; set; }

        public DateTime ModDate { get; set; }

        public Recipe? Recipe { get; set; }

        public Food? Food { get; set; }

        public MeasureUnit? MeasureUnit { get; set; }
    }
}
