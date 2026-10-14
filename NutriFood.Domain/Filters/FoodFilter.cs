namespace NutriFood.Domain.Filters;

public sealed class FoodFilter
{
    public string? Search { get; init; }

    public IReadOnlyCollection<short> CategoryIds { get; init; } = [];

    public IReadOnlyCollection<short> ClassificationIds { get; init; } = [];

    public IReadOnlyCollection<FoodAttributeFilter> AttributeFilters { get; init; } = [];

    public FoodSort? Sort { get; init; }
}
