using Atrato.Entities.DTO.Permission;
using Atrato.Services.PermissionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atrato.Api.Controllers;

[ApiController]
[Route("{enterpriseId:Guid}/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _service;

    public PermissionController(IPermissionService service)
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
    public async Task<IActionResult> Post(PermissionCreateRequest request)
    {
        var response = await _service.Post(request, User.UserId());
        return Ok(response);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put(PermissionUpdateRequest request)
    {
        var response = await _service.Put(request, User.UserId());
        return Ok(response);
    }
}
