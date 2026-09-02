using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodService : CrudService<Food, int>, IFoodService
{
    public FoodService(IFoodRepository repository) : base(repository)
    {
    }
}