using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Atrato.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid UserId(this ClaimsPrincipal principal) =>
        principal.UserIdOrNull()
        ?? throw new UnauthorizedAccessException("Token sin identificador de usuario válido.");

    public static Guid? UserIdOrNull(this ClaimsPrincipal principal) =>
        Guid.TryParse(principal.FindFirstValue(JwtRegisteredClaimNames.Sub), out var id)
            ? id
            : null;
}