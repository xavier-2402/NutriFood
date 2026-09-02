namespace NutriFood.Application.Contracts;

public sealed record FoodMenuResponse(
    int Id,
    string Code,
    string Name,
    string? Description,
    int MealPlanId,
    short? MealTimeId,
    bool Active);