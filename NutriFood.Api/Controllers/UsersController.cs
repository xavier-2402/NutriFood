using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Contracts;
using NutriFood.Application.Services.Abstractions;

namespace NutriFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
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
    public async Task<IActionResult> GetById(short id, CancellationToken ct)
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
    public async Task<IActionResult> Create(UserCreateRequest request, CancellationToken ct)
        => StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(request, ct));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(short id, UserUpdateRequest request, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
    {
        var updated = await _service.UpdateAsync(id, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(short id, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
        => await _service.DeleteAsync(id, userId, ct) ? NoContent() : NotFound();
}