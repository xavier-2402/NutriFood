using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Contracts;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Common.Pagination;

namespace NutriFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FoodController : ControllerBase
{
    private readonly IFoodService _service;

    public FoodController(IFoodService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetAllAsync(ct));
    }

    [HttpGet]
    [Route("active")]
    public async Task<IActionResult> GetAllActive(CancellationToken ct)
    {
        return Ok(await _service.GetAllActiveAsync(ct));
    }

    [HttpPost]
    [Route("seach")]
    public async Task<IActionResult> Search(
        [FromBody] FoodSearchRequest request,
        [FromQuery] int page = Pagination.DefaultPage,
        [FromQuery] int size = Pagination.DefaultPageSize,
        CancellationToken ct = default)
    {
        return Ok(await _service.SearchAsync(request, page, size, ct));
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

    [HttpGet]
    [Route("category/{categoryId}")]
    public IActionResult GetByCategory(short categoryId)
        => Ok(_service.GetByCategory(categoryId));

    [HttpGet]
    [Route("classification/{classificationId}")]
    public IActionResult GetByClassification(short classificationId)
        => Ok(_service.GetByClassification(classificationId));

    [HttpPost]
    public async Task<IActionResult> Create(FoodCreateRequest request, CancellationToken ct)
        => StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(request, ct));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, FoodUpdateRequest request, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
    {
        var updated = await _service.UpdateAsync(id, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, [FromQuery(Name = "user_id")] short userId, CancellationToken ct)
        => await _service.DeleteAsync(id, userId, ct) ? NoContent() : NotFound();
}