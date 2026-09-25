namespace NutriFood.Application.Contracts;

public sealed class RecipeCreateRequest
{
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public int FoodMenuId { get; init; }
}
