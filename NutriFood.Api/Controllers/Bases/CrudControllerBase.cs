using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Api.Controllers.Bases;

[ApiController]
[Route("api/[controller]")]
public abstract class CrudControllerBase<TEntity, TId, TRequestCreate, TRequestUpdate, TResponse> : ControllerBase
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    private readonly ICrudService<TEntity, TId> _service;

    protected CrudControllerBase(ICrudService<TEntity, TId> service)
    {
        _service = service;
    }

    protected abstract TEntity ToEntity(TRequestCreate request);
    protected abstract TEntity ToEntity(TRequestUpdate request, TEntity existing);
    protected abstract TResponse Map(TEntity entity);

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery(Name = "include_inactive")] bool includeInactive, CancellationToken ct)
    {
        var entities = includeInactive
            ? await _service.GetAllAsync(includeInactive: true, ct)
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

    [HttpPost]
    public async Task<IActionResult> Create(TRequestCreate request, CancellationToken ct)
    {
        var entity = ToEntity(request);
        var created = await _service.CreateAsync(entity, ct);
        return StatusCode(StatusCodes.Status201Created, Map(created));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(TId id, TRequestUpdate request, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
    {
        var existing = await _service.GetByIdAsync(id, includeInactive: true, ct);
        if (existing is null)
        {
            return NotFound();
        }

        var entity = ToEntity(request, existing);
        entity.Id = existing.Id;
        await _service.UpdateAsync(entity, ct);
        return Ok(Map(entity));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(TId id, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
        => await _service.DeleteAsync(id, userId, ct) ? NoContent() : NotFound();
}