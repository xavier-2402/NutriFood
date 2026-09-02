using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class AdequacyPercentageService : CrudService<AdequacyPercentage, int>, IAdequacyPercentageService
{
    public AdequacyPercentageService(IAdequacyPercentageRepository repository) : base(repository)
    {
    }
}