using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

    [HttpGet("RehydrateUser")]
    [Authorize]
    public async Task<IActionResult> RehydrateUser(CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(User.FindFirstValue(JwtRegisteredClaimNames.Sub), out var userId))
        {
            return Unauthorized();
        }

        var response = await _service.RehydrateUser(userId, cancellationToken);

        if (!response.Success)
        {
            return StatusCode(StatusCodes.Status403Forbidden, response);
        }

        return Ok(response);
    }

    [HttpPost("Logout")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout(LogoutRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.Logout(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("LogoutAll")]
    [Authorize]
    public async Task<IActionResult> LogoutAll(CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(User.FindFirstValue(JwtRegisteredClaimNames.Sub), out var userId))
        {
            return Unauthorized();
        }

        var response = await _service.LogoutAll(userId, cancellationToken);
        return Ok(response);
    }
}