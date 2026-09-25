using Microsoft.AspNetCore.Mvc;
using NutriFood.Application.Contracts;
using NutriFood.Application.Services.Abstractions;

namespace NutriFood.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RecipeFoodController : ControllerBase
{
    private readonly IRecipeFoodService _service;

    public RecipeFoodController(IRecipeFoodService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(RecipeFoodCreateRequest request, CancellationToken ct)
        => StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(request, ct));
}
