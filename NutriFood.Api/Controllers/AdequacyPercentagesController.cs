using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class AdequacyPercentagesController : CrudControllerBase<AdequacyPercentage, int, AdequacyPercentageCreateRequest, AdequacyPercentageUpdateRequest, AdequacyPercentageResponse>
{
    public AdequacyPercentagesController(IAdequacyPercentageService service) : base(service)
    {
    }

    protected override AdequacyPercentage ToEntity(AdequacyPercentageCreateRequest request) => AdequacyPercentageMapper.ToEntity(request);

    protected override AdequacyPercentage ToEntity(AdequacyPercentageUpdateRequest request, AdequacyPercentage existing) => AdequacyPercentageMapper.ToEntity(request, existing);

    protected override AdequacyPercentageResponse Map(AdequacyPercentage entity) => AdequacyPercentageMapper.Map(entity);
}