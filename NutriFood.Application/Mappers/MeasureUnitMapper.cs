using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class MeasureUnitMapper
{
    public static MeasureUnitResponse Map(MeasureUnit entity) => new(
        entity.Id,
        entity.Name,
        entity.Abbreviation,
        entity.Code,
        entity.Active);
}