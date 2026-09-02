using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class MealPlanService : CrudService<MealPlan, int>, IMealPlanService
{
    public MealPlanService(IMealPlanRepository repository) : base(repository)
    {
    }
}