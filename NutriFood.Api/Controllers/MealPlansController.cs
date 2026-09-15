using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Contracts;
using NutriFood.Application.Services.Abstractions;

namespace NutriFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class MealPlansController : ControllerBase
{
    private readonly IMealPlanService _service;

    public MealPlansController(IMealPlanService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await _service.GetAllAsync(ct));

    [HttpGet("active")]
    public async Task<IActionResult> GetAllActive(CancellationToken ct)
        => Ok(await _service.GetAllActiveAsync(ct));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var response = await _service.GetByIdAsync(id, false, ct);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpGet("code/{code}")]
    public async Task<IActionResult> GetByCode(string code, CancellationToken ct)
    {
        var response = await _service.GetByCodeAsync(code, ct);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MealPlanCreateRequest request, CancellationToken ct)
        => StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(request, ct));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MealPlanUpdateRequest request, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
    {
        var updated = await _service.UpdateAsync(id, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
        => await _service.DeleteAsync(id, userId, ct) ? NoContent() : NotFound();
}