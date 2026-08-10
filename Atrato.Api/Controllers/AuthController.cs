using Atrato.Entities.SupportDTO;
using Atrato.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Atrato.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("RequestCode")]
    [AllowAnonymous]
    [EnableRateLimiting("Limited")]
    public async Task<IActionResult> RequestCode(CheckUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.RequestCode(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    [EnableRateLimiting("Limited")]
    public async Task<IActionResult> Login(AuthRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.Login(request, cancellationToken);

        if (!response.Success)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }

    [HttpPost("Refresh")]
    [AllowAnonymous]
    [EnableRateLimiting("Limited")]
    public async Task<IActionResult> Refresh(RefreshRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.Refresh(request, cancellationToken);

        if (!response.Success)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }
}