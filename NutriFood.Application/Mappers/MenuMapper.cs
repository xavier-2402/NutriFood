using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class MenuMapper
{
    public static MenuResponse Map(Menu entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Path,
        entity.Active);
}