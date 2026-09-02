using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class MenusController : ReadOnlyControllerBase<Menu, short, MenuResponse>
{
    public MenusController(IReadOnlyService<Menu, short> service) : base(service)
    {
    }

    protected override MenuResponse Map(Menu entity) => MenuMapper.Map(entity);
}