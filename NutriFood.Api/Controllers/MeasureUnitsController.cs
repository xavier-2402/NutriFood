using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class MeasureUnitsController : ReadOnlyControllerBase<MeasureUnit, short, MeasureUnitResponse>
{
    public MeasureUnitsController(IReadOnlyService<MeasureUnit, short> service) : base(service)
    {
    }

    protected override MeasureUnitResponse Map(MeasureUnit entity) => MeasureUnitMapper.Map(entity);
}