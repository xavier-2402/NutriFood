namespace NutriFood.Application.Contracts;

public sealed record FoodMenuUpdateRequest(
    string Code,
    string Name,
    string? Description,
    int MealPlanId,
    short? MealTimeId,
    bool Active);