using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Contracts;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Common.Pagination;

namespace NutriFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PatientController : ControllerBase
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("search")]
    public async Task<IActionResult> Search(
        [FromBody] PatientSearchRequest request,
        [FromQuery] int page = Pagination.DefaultPage,
        [FromQuery] int size = Pagination.DefaultPageSize,
        CancellationToken ct = default)
    {
        short userId = 1;
        return Ok(await _service.SearchAsync(request, userId, page, size, ct));
    }

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
    public async Task<IActionResult> Create(PatientCreateRequest request, CancellationToken ct)
        => StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(request, ct));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PatientUpdateRequest request, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
    {
        var updated = await _service.UpdateAsync(id, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
        => await _service.DeleteAsync(id, userId, ct) ? NoContent() : NotFound();
}