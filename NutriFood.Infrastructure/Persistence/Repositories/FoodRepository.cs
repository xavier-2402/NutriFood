using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Common.Pagination;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Filters;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class FoodRepository(NutriFoodDbContext context) : EfCrudRepository<Food, int>(context), IFoodRepository
{
    protected override IQueryable<Food> ApplyIncludes(IQueryable<Food> query)
        => query
            .Include(food => food.FoodCategory)
            .Include(food => food.FoodClassification)
            .Include(food => food.FoodAttributeValues)
                .ThenInclude(attributeValue => attributeValue.Attribute)
                    .ThenInclude(attribute => attribute.MeasureUnit);

    public List<Food> FindByCategory(short categoryId)
    {
        return [.. ApplyIncludes(Context.Foods
            .AsNoTracking()
            .Where(x => x.Active && x.FoodCategoryId == categoryId))];
    }

    public List<Food> FindByClasification(short clasificationId)
    {
        return [.. ApplyIncludes(Context.Foods
            .AsNoTracking()
            .Where(x => x.Active && x.FoodClassificationId != null && x.FoodClassificationId == clasificationId))];
    }

    public Task<Food?> GetActiveWithAttributeValuesAsync(int foodId, CancellationToken cancellationToken)
    {
        return ApplyIncludes(Context.Foods
            .AsNoTracking())
            .FirstOrDefaultAsync(food => food.Id == foodId && food.Active, cancellationToken);
    }

    public async Task<PageResult<Food>> SearchAsync(
        FoodFilter filter,
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        var query = BuildSearchQuery(filter);

        var totalItems = await query.CountAsync(cancellationToken);
        var items = await ApplyOrdering(query, filter.Sort)
            .Skip(pagination.Skip)
            .Take(pagination.PageSize)
            .ToListAsync(cancellationToken);

        return new PageResult<Food>(items, pagination.Page, pagination.PageSize, totalItems);
    }

    private static IOrderedQueryable<Food> ApplyOrdering(IQueryable<Food> query, FoodSort? sort)
    {
        if (sort is null)
        {
            return query
                .OrderBy(food => food.Name)
                .ThenBy(food => food.Id);
        }

        Expression<Func<Food, double?>> selector =
            food => food.FoodAttributeValues
                .Where(attributeValue => attributeValue.Active && attributeValue.AttributeId == sort.AttributeId)
                .Select(attributeValue => (double?)attributeValue.Value)
                .FirstOrDefault();

        return sort.Descending
            ? query.OrderByDescending(selector).ThenBy(food => food.Id)
            : query.OrderBy(selector).ThenBy(food => food.Id);
    }

    private IQueryable<Food> BuildSearchQuery(FoodFilter filter)
    {
        IQueryable<Food> query = ApplyIncludes(Context.Foods
            .AsNoTracking())
            .Where(food => food.Active);

        var normalizedSearch = filter.Search?.Trim();
        if (!string.IsNullOrWhiteSpace(normalizedSearch))
        {
            query = query.Where(food => EF.Functions.ILike(food.Name, $"%{normalizedSearch}%"));
        }

        if (filter.CategoryIds.Count > 0)
        {
            query = query.Where(food => filter.CategoryIds.Contains(food.FoodCategoryId));
        }

        if (filter.ClassificationIds.Count > 0)
        {
            query = query.Where(food => food.FoodClassificationId.HasValue && filter.ClassificationIds.Contains(food.FoodClassificationId.Value));
        }

        foreach (var attributeFilter in filter.AttributeFilters)
        {
            query = query.Where(BuildAttributePredicate(attributeFilter));
        }

        return query;
    }

    private static Expression<Func<Food, bool>> BuildAttributePredicate(FoodAttributeFilter filter) =>
        filter.Operator switch
        {
            AttributeComparisonOperatorEnum.Equal =>
                food => food.FoodAttributeValues.Any(attributeValue =>
                    attributeValue.Active && attributeValue.AttributeId == filter.AttributeId && attributeValue.Value == filter.Value),
            AttributeComparisonOperatorEnum.NotEqual =>
                food => food.FoodAttributeValues.Any(attributeValue =>
                    attributeValue.Active && attributeValue.AttributeId == filter.AttributeId && attributeValue.Value != filter.Value),
            AttributeComparisonOperatorEnum.GreaterThan =>
                food => food.FoodAttributeValues.Any(attributeValue =>
                    attributeValue.Active && attributeValue.AttributeId == filter.AttributeId && attributeValue.Value > filter.Value),
            AttributeComparisonOperatorEnum.GreaterThanOrEqual =>
                food => food.FoodAttributeValues.Any(attributeValue =>
                    attributeValue.Active && attributeValue.AttributeId == filter.AttributeId && attributeValue.Value >= filter.Value),
            AttributeComparisonOperatorEnum.LessThan =>
                food => food.FoodAttributeValues.Any(attributeValue =>
                    attributeValue.Active && attributeValue.AttributeId == filter.AttributeId && attributeValue.Value < filter.Value),
            AttributeComparisonOperatorEnum.LessThanOrEqual =>
                food => food.FoodAttributeValues.Any(attributeValue =>
                    attributeValue.Active && attributeValue.AttributeId == filter.AttributeId && attributeValue.Value <= filter.Value),
            _ => _ => false
        };
}
