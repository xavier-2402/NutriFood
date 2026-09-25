using NutriFood.Domain.Entities;
namespace NutriFood.Domain.Repositories;
public interface IFoodMenuRepository : ICrudRepository<FoodMenu, int>
{
    Task<FoodMenu?> GetByIdAndUserIdAsync(int foodMenuId, short userId, CancellationToken cancellationToken);
}
