using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Services.Abstractions;

namespace NutriFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FoodCategoriesController : ControllerBase
{
    private readonly IFoodCategoryService _service;

    public FoodCategoriesController(IFoodCategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await _service.GetAllAsync(ct));

    [HttpGet("active")]
    public async Task<IActionResult> GetAllActive(CancellationToken ct)
        => Ok(await _service.GetAllActiveAsync(ct));

    [HttpGet("id/{id}")]
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
}