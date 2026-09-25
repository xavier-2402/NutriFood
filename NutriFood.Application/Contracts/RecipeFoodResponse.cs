namespace NutriFood.Application.Contracts;

public sealed record RecipeFoodResponse(
    int RecipeId,
    int FoodId,
    double Quantity,
    short MeasureUnitId,
    bool Active);
