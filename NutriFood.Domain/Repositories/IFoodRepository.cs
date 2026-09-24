using NutriFood.Domain.Filters;
using NutriFood.Domain.Common.Pagination;
using NutriFood.Domain.Entities;
namespace NutriFood.Domain.Repositories;
public interface IFoodRepository : ICrudRepository<Food, int> 
{
    public List<Food> FindByCategory(short categoryId);
    public List<Food> FindByClasification(short clasificationId);
    Task<PageResult<Food>> SearchAsync(
        FoodFilter filter,
        Pagination pagination,
        CancellationToken cancellationToken);
}
