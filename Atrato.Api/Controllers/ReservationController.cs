using Atrato.Entities.DTO.Reservation;
using Atrato.Services.ReservationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atrato.Api.Controllers;

[ApiController]
[Route("{EnterpriseId:Guid}/{UserId:Guid}/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _service;

    public ReservationController(IReservationService service)
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
    [HttpGet("ByWorkplace/{workplaceId:Guid}")]
    public async Task<IActionResult> ByWorkplace(Guid workplaceId, CancellationToken cancellationToken)
    {
        var response = await _service.ByWorkplace(workplaceId, cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("ByWorkStation/{workStationId:Guid}")]
    public async Task<IActionResult> ByWorkStation(Guid workStationId, CancellationToken cancellationToken)
    {
        var response = await _service.ByWorkStation(workStationId, cancellationToken);
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
    [HttpPost]
    public async Task<IActionResult> Post(ReservationCreateRequest request, Guid userId)
    {
        var response = await _service.Post(request, userId);
        return Ok(response);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put(ReservationUpdateRequest request, Guid userId)
    {
        var response = await _service.Put(request, userId);
        return Ok(response);
    }
}
