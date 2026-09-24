using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Common.Pagination;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Filters;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class FoodRepository(NutriFoodDbContext context) : EfCrudRepository<Food, int>(context), IFoodRepository
{
    public List<Food> FindByCategory(short categoryId)
    {
        return [.. Context.Foods
            .AsNoTracking()
            .Where(x => x.Active && x.FoodCategoryId == categoryId)];
    }

    public List<Food> FindByClasification(short clasificationId)
    {
        return [.. Context.Foods
            .AsNoTracking()
            .Where(x => x.Active && x.FoodClassificationId != null && x.FoodClassificationId == clasificationId)];
    }

    public async Task<PageResult<Food>> SearchAsync(
        FoodFilter filter,
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        var query = BuildSearchQuery(filter);

        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query
            .OrderBy(food => food.Name)
            .ThenBy(food => food.Id)
            .Skip(pagination.Skip)
            .Take(pagination.PageSize)
            .ToListAsync(cancellationToken);

        return new PageResult<Food>(items, pagination.Page, pagination.PageSize, totalItems);
    }

    private IQueryable<Food> BuildSearchQuery(FoodFilter filter)
    {
        IQueryable<Food> query = Context.Foods
            .AsNoTracking()
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

        return query;
    }
}
