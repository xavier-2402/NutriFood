namespace NutriFood.Application.Contracts;

public sealed record FoodMenuCreateRequest(
    string Code,
    string Name,
    string? Description,
    int MealPlanId,
    short? MealTimeId);