using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodMenuService : CrudService<FoodMenu, int>, IFoodMenuService
{
    public FoodMenuService(IFoodMenuRepository repository) : base(repository)
    {
    }
}