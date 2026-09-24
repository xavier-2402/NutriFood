namespace NutriFood.Domain.Filters;

public sealed class FoodFilter
{
    public string? Search { get; init; }

    public IReadOnlyCollection<short> CategoryIds { get; init; } = [];

    public IReadOnlyCollection<short> ClassificationIds { get; init; } = [];
}
