using Atrato.Entities.DTO.Area;
using Atrato.Services.AreaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atrato.Api.Controllers;

[ApiController]
[Route("{EnterpriseId:Guid}/{UserId:Guid}/[controller]")]
public class AreaController : ControllerBase
{
    private readonly IAreaService _service;

    public AreaController(IAreaService service)
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
    [HttpGet("ByEnterprise")]
    public async Task<IActionResult> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _service.ByEnterprise(enterpriseId, cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post(AreaCreateRequest request, Guid userId)
    {
        var response = await _service.Post(request, userId);
        return Ok(response);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put(AreaUpdateRequest request, Guid userId)
    {
        var response = await _service.Put(request, userId);
        return Ok(response);
    }
}
