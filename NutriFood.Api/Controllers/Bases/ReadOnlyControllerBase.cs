using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Api.Controllers.Bases;

[ApiController]
[Route("api/[controller]")]
public abstract class ReadOnlyControllerBase<TEntity, TId, TResponse> : ControllerBase
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    private readonly IReadOnlyService<TEntity, TId> _service;

    protected ReadOnlyControllerBase(IReadOnlyService<TEntity, TId> service)
    {
        _service = service;
    }

    protected abstract TResponse Map(TEntity entity);

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery(Name = "include_inactive")] bool includeInactive, CancellationToken ct)
    {
        var entities = includeInactive
            ? await _service.GetAllAsync(ct)
            : await _service.GetAllActiveAsync(ct);
        return Ok(entities.Select(Map).ToList());
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetAllActive(CancellationToken ct)
    {
        var entities = await _service.GetAllActiveAsync(ct);
        return Ok(entities.Select(Map).ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(TId id, [FromQuery(Name = "include_inactive")] bool includeInactive, CancellationToken ct)
    {
        var entity = includeInactive
            ? await _service.GetByIdAsync(id, includeInactive: true, ct)
            : await _service.GetByIdAsync(id, ct);
        return entity is null ? NotFound() : Ok(Map(entity));
    }
}