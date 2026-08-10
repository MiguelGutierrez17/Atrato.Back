using Atrato.Entities.DTO.Notification;
using Atrato.Services.NotificationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atrato.Api.Controllers;

[ApiController]
[Route("{enterpriseId:Guid}/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationController(INotificationService service)
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
    [HttpGet("ByUser/{id:Guid}")]
    public async Task<IActionResult> ByUser(Guid id, CancellationToken cancellationToken)
    {
        var response = await _service.ByUser(id, cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("ByUserEnterprise")]
    public async Task<IActionResult> ByUserEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _service.ByUserEnterprise(User.UserId(), enterpriseId, cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post(NotificationCreateRequest request)
    {
        var response = await _service.Post(request, User.UserId());
        return Ok(response);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put(NotificationUpdateRequest request)
    {
        var response = await _service.Put(request, User.UserId());
        return Ok(response);
    }
}
