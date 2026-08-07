using Atrato.Entities.DTO.Enterprise;
using Atrato.Services.EnterpriseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atrato.Api.Controllers;

[ApiController]
[Route("{EnterpriseId:Guid}/{UserId:Guid}/[controller]")]
public class EnterpriseController : ControllerBase
{
    private readonly IEnterpriseService _service;

    public EnterpriseController(IEnterpriseService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _service.GetAll(cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("ById/{id:Guid}")]
    public async Task<IActionResult> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _service.ById(id, cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post(EnterpriseCreateRequest request, Guid userId)
    {
        var response = await _service.Post(request, userId);
        return Ok(response);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put(EnterpriseUpdateRequest request, Guid userId)
    {
        var response = await _service.Put(request, userId);
        return Ok(response);
    }
}