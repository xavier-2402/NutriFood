namespace NutriFood.Application.Contracts;

public sealed class RecipeFoodCreateRequest
{
    public int RecipeId { get; init; }

    public int FoodId { get; init; }

    public double Quantity { get; init; }

    public short MeasureUnitId { get; init; }
}
