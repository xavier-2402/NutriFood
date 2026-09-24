using NutriFood.Domain.Entities;
namespace NutriFood.Domain.Repositories;
public interface IFoodRepository : ICrudRepository<Food, int> 
{
    public List<Food> FindByCategory(short categoryId);
    public List<Food> FindByClasification(short clasificationId);
}
