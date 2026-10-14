using NutriFood.Domain.Filters;

namespace NutriFood.Application.Contracts;

public sealed class FoodSearchRequest
{
    public string? Search { get; init; }

    public List<short> CategoryIds { get; init; } = [];

    public List<short> ClassificationIds { get; init; } = [];

    public List<FoodAttributeFilter> AttributeFilters { get; init; } = [];

    public FoodSort? Sort { get; init; }
}
