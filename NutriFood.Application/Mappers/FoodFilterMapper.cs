using NutriFood.Application.Contracts;
using NutriFood.Domain.Filters;

namespace NutriFood.Application.Mappers;

public static class FoodFilterMapper
{
    public static FoodFilter ToFilter(FoodSearchRequest request) => new()
    {
        Search = request.Search,
        CategoryIds = request.CategoryIds,
        ClassificationIds = request.ClassificationIds
    };
}
